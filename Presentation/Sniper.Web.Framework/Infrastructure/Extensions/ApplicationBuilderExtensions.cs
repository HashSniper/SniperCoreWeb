using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Sniper.Core.Configuration;
using Sniper.Core.Data;
using Sniper.Core.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Sniper.Services.Logging;
using Sniper.Core;
using Sniper.Core.Domain.Common;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.FileProviders;
using Sniper.Core.Domain.Security;
using System.Linq;
using Sniper.Services.Media.RoxyFileman;
using Sniper.Services.Common;
using Sniper.Services.Installation;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Sniper.Web.Framework.Globalization;
using WebMarkupMin.AspNetCore2;
using Sniper.Web.Framework.Mvc.Routing;
using Sniper.Services.Localization;

namespace Sniper.Web.Framework.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureRequestPipeline(this IApplicationBuilder application)
        {
            EngineContext.Current.ConfigureRequestPipeline(application);
        }

        public static void UseNopAuthentication(this IApplicationBuilder application)
        {
            //check whether database is installed
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            application.UseMiddleware<AuthenticationMiddleware>();
        }

        /// <summary>
        /// 添加 异常处理
        /// </summary>
        /// <param name="application"></param>
        public static void UseNopExceptionHandler(this IApplicationBuilder application)
        {
            var nopConfig = EngineContext.Current.Resolve<NopConfig>();

            var hostingEnvironment = EngineContext.Current.Resolve<IHostingEnvironment>();

            var useDetailedExceptionPage = nopConfig.DisplayFullErrorStack || hostingEnvironment.IsDevelopment();

            if (useDetailedExceptionPage)
            {
                application.UseDeveloperExceptionPage();
            }
            else
            {
                application.UseExceptionHandler("/Error/Error");
            }
        }

        /// <summary>
        /// 添加特殊处理400错误
        /// </summary>
        /// <param name="application"></param>
        public static void UseBadRequestResult(this IApplicationBuilder application)
        {
            application.UseStatusCodePages(context =>
            {
                if (context.HttpContext.Response.StatusCode == StatusCodes.Status400BadRequest)
                {
                    var logger = EngineContext.Current.Resolve<ILogger>();
                    var workContext = EngineContext.Current.Resolve<IWorkContext>();
                    logger.Error("Error 400. Bad request", null, customer: workContext.CurrentCustomer);
                }
                return Task.CompletedTask;
            });
        }

        /// <summary>
        /// 404错误处理
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public static void UsePageNotFound(this IApplicationBuilder application)
        {
            application.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode== StatusCodes.Status404NotFound)
                {
                    var webHelper = EngineContext.Current.Resolve<IWebHelper>();
                    if (!webHelper.IsStaticResource())
                    {
                        var originalPath= context.HttpContext.Request.Path;
                        var originalQueryString= context.HttpContext.Request.QueryString;

                        context.HttpContext.Features.Set<IStatusCodeReExecuteFeature>(new StatusCodeReExecuteFeature
                        {
                            OriginalPathBase = context.HttpContext.Request.PathBase.Value,
                            OriginalPath = originalPath.Value,
                            OriginalQueryString = originalQueryString.HasValue ? originalQueryString.Value : null
                        });

                        //get new path
                        context.HttpContext.Request.Path = "/page-not-found";
                        context.HttpContext.Request.QueryString = QueryString.Empty;

                        try
                        {
                            //re-execute request with new path
                            await context.Next(context.HttpContext);
                        }
                        finally
                        {
                            //return original path to request
                            context.HttpContext.Request.QueryString = originalQueryString;
                            context.HttpContext.Request.Path = originalPath;
                            context.HttpContext.Features.Set<IStatusCodeReExecuteFeature>(null);
                        }
                    }
                }

            });
        }

        /// <summary>
        /// 配置中间件用以动态压缩HTTP响应
        /// </summary>
        /// <param name="application"></param>
        public static void UseNopResponseCompression(this IApplicationBuilder application)
        {
            if (DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<CommonSettings>().UseResponseCompression)
            {
                application.UseResponseCompression();
            }
        }

        /// <summary>
        /// 配置静态文件服务
        /// </summary>
        /// <param name="application"></param>
        public static void UseNopStaticFiles(this IApplicationBuilder application)
        {
            void staticFileResponse(StaticFileResponseContext context)
            {
                if (!DataSettingsManager.DatabaseIsInstalled)
                {
                    return;
                }

                var commonSettings = EngineContext.Current.Resolve<CommonSettings>();

                if (!string.IsNullOrEmpty(commonSettings.StaticFilesCacheControl))
                    context.Context.Response.Headers.Append(HeaderNames.CacheControl, commonSettings.StaticFilesCacheControl);
            }

            var fileProvider = EngineContext.Current.Resolve<INopFileProvider>();

            application.UseStaticFiles(new StaticFileOptions { OnPrepareResponse = staticFileResponse });

            application.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(fileProvider.MapPath(@"Themes")),
                RequestPath = new PathString("/Themes"),
                OnPrepareResponse = staticFileResponse
            });

            var staticFileOptions = new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(fileProvider.MapPath(@"Plugins")),
                RequestPath = new PathString("/Plugins"),
                OnPrepareResponse = staticFileResponse
            };

            if (DataSettingsManager.DatabaseIsInstalled)
            {
                var securitySettings = EngineContext.Current.Resolve<SecuritySettings>();

                if (!string.IsNullOrEmpty(securitySettings.PluginStaticFileExtensionsBlacklist))
                {
                    var fileExtensionContentTypeProvider = new FileExtensionContentTypeProvider();

                    foreach (var ext in securitySettings.PluginStaticFileExtensionsBlacklist
                    .Split(';',',')
                    .Select(e=>e.Trim().ToLower())
                    .Select(e=>$"{(e.StartsWith(".")?string.Empty:".")}{e}")
                    .Where(fileExtensionContentTypeProvider.Mappings.ContainsKey)
                    )
                    {
                        fileExtensionContentTypeProvider.Mappings.Remove(ext);
                    }

                    staticFileOptions.ContentTypeProvider = fileExtensionContentTypeProvider;
                }
            }

            application.UseStaticFiles(staticFileOptions);

            var provider = new FileExtensionContentTypeProvider
            {
                Mappings = { [".bak"] = MimeTypes.ApplicationOctetStream }
            };

            application.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(fileProvider.GetAbsolutePath("icons")),
                RequestPath = "/icons",
                ContentTypeProvider = provider
            });

            if (DataSettingsManager.DatabaseIsInstalled)
            {
                application.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new RoxyFilemanProvider(fileProvider.GetAbsolutePath(NopRoxyFilemanDefaults.DefaultRootDirectory.TrimStart('/').Split('/'))),
                    RequestPath = new PathString(NopRoxyFilemanDefaults.DefaultRootDirectory),
                    OnPrepareResponse = staticFileResponse
                });
            }
        }

        /// <summary>
        /// 配置中间件检查请求的页面是否保持活动页面
        /// </summary>
        /// <param name="application"></param>
        public static void UseKeepAlive(this IApplicationBuilder application)
        {
            application.UseMiddleware<KeepAliveMiddleware>();
        }

        /// <summary>
        /// 配置中间件检查数据库是否已安装
        /// </summary>
        /// <param name="application"></param>
        public static void UseInstallUrl(this IApplicationBuilder application)
        {
            application.UseMiddleware<InstallUrlMiddleware>();
        }

        /// <summary>
        /// 配置请求本地话功能
        /// </summary>
        /// <param name="application"></param>
        public static void UseNopRequestLocalization(this IApplicationBuilder application)
        {
            application.UseRequestLocalization(options =>
            {
                if (!DataSettingsManager.DatabaseIsInstalled)
                    return;

                var cultures = EngineContext.Current.Resolve<ILanguageService>().GetAllLanguages()
                .OrderBy(language => language.DisplayOrder)
                .Select(language => new CultureInfo(language.LanguageCulture)).ToList();
                options.SupportedCultures = cultures;
                options.DefaultRequestCulture = new RequestCulture(cultures.FirstOrDefault());
            });
        }

        /// <summary>
        /// 设置当前文化信息
        /// </summary>
        /// <param name="application"></param>
        public static void UseCulture(this IApplicationBuilder application)
        {
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            application.UseMiddleware<CultureMiddleware>();
        }

        /// <summary>
        /// 配置WebMarkupMin
        /// </summary>
        /// <param name="application"></param>
        public static void UseNopWebMarkupMin(this IApplicationBuilder application)
        {
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            application.UseWebMarkupMin();
        }

        /// <summary>
        /// 配置mvc路由
        /// </summary>
        /// <param name="application"></param>
        public static void UseNopMvc(this IApplicationBuilder application)
        {
            application.UseMvc(routeBuilder =>
            {
                EngineContext.Current.Resolve<IRoutePublisher>().RegisterRoutes(routeBuilder);
            });
        }
    }
}

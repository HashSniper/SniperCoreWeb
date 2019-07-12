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

namespace Sniper.Web.Framework.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
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
    }
}

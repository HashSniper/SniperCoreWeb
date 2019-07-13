
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Configuration;
using Sniper.Core.Data;
using Sniper.Core.Domain.Security;
using Sniper.Core.Http;
using Sniper.Core.Infrastructure;
using Sniper.Core.Redis;
using Sniper.Services.Authentication;
using Sniper.Services.Authentication.External;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using EasyCaching.InMemory;
using EasyCaching.Core;
using Sniper.Services.Common;
using Sniper.Web.Framework.Security.Captcha;
using Microsoft.AspNetCore.Mvc.Razor;
using Sniper.Web.Framework.Themes;
using Sniper.Data;
using StackExchange.Profiling.Storage;
using Sniper.Core.Domain.Stores;
using Sniper.Services.Security;
using WebMarkupMin.AspNetCore2;
using Sniper.Core.Domain.Common;
using WebMarkupMin.NUglify;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Sniper.Web.Framework.Mvc.ModelBinding;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Sniper.Web.Framework.Mvc.Routing;

namespace Sniper.Web.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var nopConfig = services.ConfigureStartupConfig<NopConfig>(configuration.GetSection("Nop"));

            services.ConfigureStartupConfig<HostingConfig>(configuration.GetSection("Hosting"));

            services.AddHttpContextAccessor();

            CommonHelper.DefaultFileProvider = new NopFileProvider(hostingEnvironment);

            var mvcCoreBuilder = services.AddMvcCore();
            mvcCoreBuilder.PartManager.InitializePlugins(nopConfig);

            var engine = EngineContext.Create();

            var serviceProvider = engine.ConfigureServices(services, configuration, nopConfig);
            return null;
        }

        public static TConfig ConfigureStartupConfig<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            //create instance of config
            var config = new TConfig();

            //bind it to the appropriate section of configuration
            configuration.Bind(config);
            //将单例注册到service中
            services.AddSingleton(config);

            return config;
        }

        /// <summary>
        /// 注册 HttpContextAccessor
        /// </summary>
        /// <param name="services"></param>
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        /// <summary>
        /// 添加数据保护
        /// </summary>
        /// <param name="services"></param>
        public static void AddNopDataProtection(this IServiceCollection services)
        {
            var nopConfig = services.BuildServiceProvider().GetRequiredService<NopConfig>();

            if (nopConfig.RedisEnabled && nopConfig.UseRedisToStoreDataProtectionKeys)
            {
                services.AddDataProtection().PersistKeysToRedis(() =>
                {
                    var redisConnectionWrapper = EngineContext.Current.Resolve<IRedisConnectionWrapper>();
                    return redisConnectionWrapper.GetDatabase(nopConfig.RedisDatabaseId ?? (int)RedisDatabaseNumber.DataProtectionKeys);
                }, NopCachingDefaults.RedisDataProtectionKey);
            }
            else
            {
                var dataProtectionKeysPath = CommonHelper.DefaultFileProvider.MapPath("~/App_Data/DataProtectionKeys");

                var dataProtectionKeysFolder =new DirectoryInfo(dataProtectionKeysPath);

                services.AddDataProtection().PersistKeysToFileSystem(dataProtectionKeysFolder);

            }
        }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="services"></param>
        public static void AddNopAuthentication(this IServiceCollection services)
        {
            var authenticationBuilder = services.AddAuthentication(options =>
              {
                  options.DefaultAuthenticateScheme = NopAuthenticationDefaults.AuthenticationScheme;
                  options.DefaultScheme = NopAuthenticationDefaults.AuthenticationScheme;
                  options.DefaultSignInScheme = NopAuthenticationDefaults.ExternalAuthenticationScheme;
              });

            authenticationBuilder.AddCookie(NopAuthenticationDefaults.AuthenticationScheme, options =>
             {
                 options.Cookie.Name = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.AuthenticationCookie}";

                 options.Cookie.HttpOnly = true;

                 options.LoginPath = NopAuthenticationDefaults.LoginPath;

                 options.AccessDeniedPath = NopAuthenticationDefaults.AccessDeniedPath;

                 options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages ?
                 CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;

             });

            authenticationBuilder.AddCookie(NopAuthenticationDefaults.ExternalAuthenticationScheme, options =>
             {
                 options.Cookie.Name = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.ExternalAuthenticationCookie}";
                 options.Cookie.HttpOnly = true;
                 options.LoginPath = NopAuthenticationDefaults.LoginPath;
                 options.AccessDeniedPath = NopAuthenticationDefaults.AccessDeniedPath;

                 options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages ?
                 CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
             });

            var typeFinder = new WebAppTypeFinder();

            var externalAuthConfigurations = typeFinder.FindClassesOfType<IExternalAuthenticationRegistrar>();
            var externalAuthInstances = externalAuthConfigurations.Select(x => (IExternalAuthenticationRegistrar)Activator.CreateInstance(x));

            foreach (var instance in externalAuthInstances)
            {
                instance.Configure(authenticationBuilder);
            }
        }

        /// <summary>
        /// 配置EasyCaching 服务
        /// </summary>
        /// <param name="services"></param>
        public static void AddEasyCaching(this IServiceCollection services)
        {
            services.AddEasyCaching(option =>
            {
                option.UseInMemory("nopCommerce_memory_cache");
            });
        }

        /// <summary>
        /// 添加应用程序会话状态所需的服务
        /// </summary>
        /// <param name="services"></param>
        public static void AddHttpSession(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.Cookie.Name = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.SessionCookie}";
                options.Cookie.HttpOnly = true;

                options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages ?
                CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
            });
        }

        /// <summary>
        /// 配置默认http 客户端
        /// </summary>
        /// <param name="services"></param>
        public static void AddNopHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient(NopHttpDefaults.DefaultHttpClient).WithProxy();

            services.AddHttpClient<StoreHttpClient>();

            services.AddHttpClient<NopHttpClient>().WithProxy();

            services.AddHttpClient<CaptchaHttpClient>().WithProxy();
        }

        /// <summary>
        /// 添加反伪造服务
        /// </summary>
        /// <param name="services"></param>
        public static void AddAntiForgery(this IServiceCollection services)
        {
            services.AddAntiforgery(options =>
            {
                options.Cookie.Name = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.AntiforgeryCookie}";

                options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages ?
                CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
            });

        }

        /// <summary>
        /// 添加主题
        /// </summary>
        /// <param name="services"></param>
        public static void AddThemes(this IServiceCollection services)
        {
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            services.Configure<RazorViewEngineOptions>(optios =>
            {
                optios.ViewLocationExpanders.Add(new ThemeableViewLocationExpander());
            });
        }

        public static void AddNopObjectContext(this IServiceCollection services)
        {
            services.AddDbContextPool<NopObjectContext>(opyions =>
            {
                opyions.UseSqlServerWithLazyLoading(services);
            });
        }

        /// <summary>
        /// 配置NopMini
        /// </summary>
        /// <param name="services"></param>
        public static void AddNopMiniProfiler(this IServiceCollection services)
        {
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            services.AddMiniProfiler(miniProfilerOptions =>
            {
                ((MemoryCacheStorage)miniProfilerOptions.Storage).CacheDuration = TimeSpan.FromMinutes(60);
                miniProfilerOptions.ShouldProfile = request =>
                  EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerInPublicStore;

                miniProfilerOptions.ResultsAuthorize = request =>
                  !EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerForAdminOnly ||
                  EngineContext.Current.Resolve<IPermissionService>().Authorize(StandardPermissionProvider.AccessAdminPanel);
            }).AddEntityFramework();
        }

        /// <summary>
        /// 添加和配置WebMarkupMin服务
        /// </summary>
        /// <param name="services"></param>
        public static void AddNopWebMarkupMin(this IServiceCollection services)
        {
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            services
                .AddWebMarkupMin(options =>
                {
                    options.AllowMinificationInDevelopmentEnvironment = true;
                    options.AllowCompressionInDevelopmentEnvironment = true;
                    options.DisableMinification = !EngineContext.Current.Resolve<CommonSettings>().EnableHtmlMinification;
                    options.DisableCompression = true;
                    options.DisablePoweredByHttpHeaders = true;
                })
                .AddHtmlMinification(options =>
                {
                    var settings = options.MinificationSettings;
                    options.CssMinifierFactory = new NUglifyCssMinifierFactory();
                    options.JsMinifierFactory = new NUglifyJsMinifierFactory();
                })
                .AddXmlMinification(options =>
                {
                    var settings = options.MinificationSettings;
                    settings.RenderEmptyTagsWithSpace = true;
                    settings.CollapseTagsWithoutContent = true;
                });
        }

        /// <summary>
        /// 为应用程序添加和配置MVC
        /// </summary>
        /// <param name="services"></param>
        public static IMvcBuilder AddNopMvc(this IServiceCollection services)
        {
            var mvcBuilder = services.AddMvc();
            mvcBuilder.AddMvcOptions(options => options.EnableEndpointRouting = false);

            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var nopConfig = services.BuildServiceProvider().GetRequiredService<NopConfig>();

            if (nopConfig.UseSessionStateTempDataProvider)
            {
                mvcBuilder.AddSessionStateTempDataProvider();
            }
            else
            {
                mvcBuilder.AddCookieTempDataProvider(options =>
                {
                    options.Cookie.Name = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.TempDataCookie}";

                    //whether to allow the use of cookies from SSL protected page on the other store pages which are not
                    options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                        ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
                });
            }

            mvcBuilder.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            mvcBuilder.AddMvcOptions(options => options.ModelMetadataDetailsProviders.Add(new NopMetadataProvider()));

            mvcBuilder.AddMvcOptions(options => options.ModelBinderProviders.Insert(0, new NopModelBinderProvider()));

            mvcBuilder.AddFluentValidation(configuration =>
            {
                var assemblies = mvcBuilder.PartManager.ApplicationParts.OfType<AssemblyPart>()
                .Where(part => part.Name.StartsWith("Nop", StringComparison.InvariantCultureIgnoreCase))
                .Select(part => part.Assembly);
                configuration.RegisterValidatorsFromAssemblies(assemblies);

                configuration.ImplicitlyValidateChildProperties = true;
            });

            mvcBuilder.AddControllersAsServices();

            return mvcBuilder;
        }

        /// <summary>
        /// 注册自定义RedirectResultExecutor
        /// </summary>
        /// <param name="services"></param>
        public static void AddNopRedirectResultExecutor(this IServiceCollection services)
        {
            //we use custom redirect executor as a workaround to allow using non-ASCII characters in redirect URLs
            services.AddSingleton<IActionResultExecutor<RedirectResult>, NopRedirectResultExecutor>();
        }
    }
}

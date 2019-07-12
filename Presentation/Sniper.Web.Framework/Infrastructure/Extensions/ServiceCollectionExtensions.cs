
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
            
        }
    }
}

using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Microsoft.EntityFrameworkCore;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Configuration;
using Sniper.Core.Data;
using Sniper.Core.Infrastructure;
using Sniper.Core.Infrastructure.DependencyManagement;
using Sniper.Core.Redis;
using Sniper.Data;
using Sniper.Services.Common;
using Sniper.Services.Configuration;
using Sniper.Services.Events;
using Sniper.Services.Localization;
using Sniper.Services.Logging;
using Sniper.Services.Plugins;
using Sniper.Services.Security;
using Sniper.Services.Stores;
using Sniper.Services.Tasks;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sniper.Web.Framework.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order =>0;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            //file provider
            builder.RegisterType<NopFileProvider>().As<INopFileProvider>().InstancePerLifetimeScope();

            //web helper
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();


            builder.Register(context => new NopObjectContext(context.Resolve<DbContextOptions<NopObjectContext>>()))
                .As<IDbContext>().InstancePerLifetimeScope();

            //plugins
            builder.RegisterType<PluginService>().As<IPluginService>().InstancePerLifetimeScope();


            //redis connection wrapper
            if (config.RedisEnabled)
            {
                builder.RegisterType<RedisConnectionWrapper>()
                    .As<ILocker>()
                    .As<IRedisConnectionWrapper>()
                    .SingleInstance();
            }


            //work context
            builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerLifetimeScope();
            //store context
            builder.RegisterType<WebStoreContext>().As<IStoreContext>().InstancePerLifetimeScope();
            builder.RegisterType<PermissionService>().As<IPermissionService>().InstancePerLifetimeScope();    
            builder.RegisterType<LocalizationService>().As<ILocalizationService>().InstancePerLifetimeScope();
            builder.RegisterType<ScheduleTaskService>().As<IScheduleTaskService>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<GenericAttributeService>().As<IGenericAttributeService>().InstancePerLifetimeScope();
            builder.RegisterType<StoreService>().As<IStoreService>().InstancePerLifetimeScope();

            builder.RegisterType<EventPublisher>().As<IEventPublisher>().SingleInstance();

            builder.RegisterType<SettingService>().As<ISettingService>().InstancePerLifetimeScope();
            builder.RegisterType<DefaultLogger>().As<ILogger>().InstancePerLifetimeScope();

            if (config.RedisEnabled && config.UseRedisForCaching)
            {
                builder.RegisterType<RedisCacheManager>().As<IStaticCacheManager>().InstancePerLifetimeScope();
            }
            else
            {
                builder.RegisterType<MemoryCacheManager>()
                    .As<ILocker>()
                    .As<IStaticCacheManager>()
                    .SingleInstance();
            }

            builder.RegisterSource(new SettingsSource());
        }
    }

    public class SettingsSource : IRegistrationSource
    {
        private static readonly MethodInfo _buildMethod =typeof(SettingsSource).GetMethod("BuildRegistration", BindingFlags.Static | BindingFlags.NonPublic);
        /// <summary>
        /// 适用各个组件
        /// </summary>
        public bool IsAdapterForIndividualComponents => false;


        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            var ts = service as TypedService;
            if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
            {
                var buildMethod = _buildMethod.MakeGenericMethod(ts.ServiceType);
                yield return (IComponentRegistration)buildMethod.Invoke(null, null);
            }
        }

        private static IComponentRegistration BuildRegistration<TSettings>() where TSettings : ISettings, new()
        {
            return RegistrationBuilder
                .ForDelegate((c, p) =>
                {
                    var currentStoreId = c.Resolve<IStoreContext>().CurrentStore.Id;

                    return c.Resolve<ISettingService>().LoadSetting<TSettings>(currentStoreId);
                })
                .InstancePerLifetimeScope()
                .CreateRegistration();
        }
    }

}

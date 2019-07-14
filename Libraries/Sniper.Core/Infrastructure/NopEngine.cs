using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sniper.Core.Configuration;
using Sniper.Core.Infrastructure.DependencyManagement;
using Sniper.Core.Infrastructure.Mapper;

namespace Sniper.Core.Infrastructure
{
    public class NopEngine : IEngine
    {
        #region Properties
        private IServiceProvider _serviceProvider { get; set; }
        public virtual IServiceProvider ServiceProvider => _serviceProvider;
        #endregion


        #region Utilities

        /// <summary>
        /// 注册并配置AutoMapper
        /// </summary>
        /// <param name="services"></param>
        /// <param name="typeFinder"></param>
        protected virtual void AddAutoMapper(IServiceCollection services, ITypeFinder typeFinder)
        {
            var mapperConfigurations = typeFinder.FindClassesOfType<IOrderedMapperProfile>();

            var instances = mapperConfigurations.Select(mapperConfiguration => (IOrderedMapperProfile)Activator.CreateInstance(mapperConfiguration))
                .OrderBy(mapperConfiguration => mapperConfiguration.Order);

            var config = new MapperConfiguration(cfg =>
              {
                  foreach (var instance in instances)
                  {
                      cfg.AddProfile(instance.GetType());
  
                  }
              });

            AutoMapperConfiguration.Init(config);

        }
        /// <summary>
        /// 注册依赖项
        /// </summary>
        /// <param name="services"></param>
        /// <param name="typeFinder"></param>
        /// <param name="nopConfig"></param>
        /// <returns></returns>
        protected virtual IServiceProvider RegisterDependencies(IServiceCollection services, ITypeFinder typeFinder, NopConfig nopConfig)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(this).As<IEngine>().SingleInstance();

            containerBuilder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            containerBuilder.Populate(services);

            var dependencyRegistrars = typeFinder.FindClassesOfType<IDependencyRegistrar>();

            var instances = dependencyRegistrars.Select(p => (IDependencyRegistrar)Activator.CreateInstance(p))
                .OrderBy(p => p.Order);

            foreach (var instance in instances)
            {
                instance.Register(containerBuilder, typeFinder, nopConfig);
            }

            _serviceProvider = new AutofacServiceProvider(containerBuilder.Build());

            return _serviceProvider;

        }

        /// <summary>
        /// 启动开始线程
        /// </summary>
        /// <param name="typeFinder"></param>
        protected virtual void RunStartupTasks(ITypeFinder typeFinder)
        {
            var startupTasks = typeFinder.FindClassesOfType<IStartupTask>();

            var instances = startupTasks.Select(p => (IStartupTask)Activator.CreateInstance(p))
                .OrderBy(p => p.Order);

            foreach (var task in instances)
            {
                task.Execute();
            }
        }

        /// <summary>
        /// 解析程序集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
            if (assembly == null)
                return assembly;

            var tf = Resolve<ITypeFinder>();

            assembly = tf.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
            return assembly;
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <returns></returns>
        protected IServiceProvider GetServiceProvider()
        {
            var accessor = ServiceProvider.GetService<IHttpContextAccessor>();
            var context = accessor.HttpContext;
            return context?.RequestServices ?? ServiceProvider;
        }

        #endregion

        #region Methods
        public void ConfigureRequestPipeline(IApplicationBuilder application)
        {
            throw new NotImplementedException();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services, IConfiguration configuration, NopConfig nopConfig)
        {
            var typeFinder = new WebAppTypeFinder();
            var startupConfigurations = typeFinder.FindClassesOfType<INopStartup>();

            var instances = startupConfigurations.Select(startup => (INopStartup)Activator.CreateInstance(startup)).OrderBy(p => p.Order);

            foreach (var instance in instances)
            {
                instance.ConfigureServices(services, configuration);
            }

            AddAutoMapper(services, typeFinder);

            RegisterDependencies(services, typeFinder, nopConfig);

            RunStartupTasks(typeFinder);

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            return _serviceProvider;
        }

        /// <summary>
        ///解析程序集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>() where T : class
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            return GetServiceProvider().GetService(type);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            throw new NotImplementedException();
        }

        public object ResolveUnregistered(Type type)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

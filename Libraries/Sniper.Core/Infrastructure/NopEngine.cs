using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sniper.Core.Configuration;

namespace Sniper.Core.Infrastructure
{
    public class NopEngine : IEngine
    {
        #region Properties
        private IServiceProvider _serviceProvider { get; set; }
        public virtual IServiceProvider ServiceProvider => _serviceProvider;
        #endregion


        #region Utilities


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

            return _serviceProvider;
        }

        public T Resolve<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
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

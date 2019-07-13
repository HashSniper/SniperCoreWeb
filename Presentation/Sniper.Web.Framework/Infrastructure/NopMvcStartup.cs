using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sniper.Core.Infrastructure;
using Sniper.Web.Framework.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework.Infrastructure
{
    public class NopMvcStartup : INopStartup
    {
        public int Order => 1000;

        public void Configure(IApplicationBuilder application)
        {
            //use MiniProfiler
            application.UseMiniProfiler();

            //use WebMarkupMin
            application.UseNopWebMarkupMin();

            //MVC routing
            application.UseNopMvc();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddNopMiniProfiler();

            //add WebMarkupMin services to the services container
            services.AddNopWebMarkupMin();

            //add and configure MVC feature
            services.AddNopMvc();

            //add custom redirect result executor
            services.AddNopRedirectResultExecutor();
        }
    }
}

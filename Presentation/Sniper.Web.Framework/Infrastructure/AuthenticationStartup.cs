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
    public class AuthenticationStartup : INopStartup
    {

        public int Order => 500;

        public void Configure(IApplicationBuilder application)
        {
            application.UseNopAuthentication();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddNopDataProtection();

            services.AddNopAuthentication();
        }
    }
}

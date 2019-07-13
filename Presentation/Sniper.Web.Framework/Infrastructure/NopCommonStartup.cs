using EasyCaching.Core;
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
    public class NopCommonStartup : INopStartup
    {
        public int Order => 100;

        public void Configure(IApplicationBuilder application)
        {
            application.UseNopResponseCompression();

            application.UseNopStaticFiles();

            application.UseKeepAlive();

            application.UseInstallUrl();

            application.UseSession();

            application.UseNopRequestLocalization();

            application.UseCulture();

            application.UseEasyCaching();

        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddResponseCompression();

            services.AddOptions();

            services.AddEasyCaching();

            services.AddDistributedMemoryCache();

            services.AddHttpSession();

            services.AddNopHttpClients();

            services.AddAntiForgery();

            services.AddLocalization();
            services.AddThemes();
        }
    }
}

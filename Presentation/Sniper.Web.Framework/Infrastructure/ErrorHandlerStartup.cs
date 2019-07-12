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
    public class ErrorHandlerStartup : INopStartup
    {
        public int Order => 0;

        public void Configure(IApplicationBuilder application)
        {
            application.UseNopExceptionHandler();

            application.UseBadRequestResult();//400错误处理

            application.UsePageNotFound();//404错误处理
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            
        }
    }
}

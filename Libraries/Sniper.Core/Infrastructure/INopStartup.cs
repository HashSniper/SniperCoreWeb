using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Infrastructure
{
    public interface INopStartup
    {
        /// <summary>
        /// 添加配置中间件
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);

        /// <summary>
        /// 配置正在使用的中间件
        /// </summary>
        /// <param name="application"></param>
        void Configure(IApplicationBuilder application);

        /// <summary>
        /// 排序
        /// </summary>
        int Order { get; }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Infrastructure
{
    public interface IEngine
    {
        /// <summary>
        /// 添加服务配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="nopConfig"></param>
        /// <returns></returns>
        IServiceProvider ConfigureServices(IServiceCollection services, IConfiguration configuration, NopConfig nopConfig);

        /// <summary>
        /// 配置http管道
        /// </summary>
        /// <param name="application"></param>
        void ConfigureRequestPipeline(IApplicationBuilder application);

        /// <summary>
        /// 解析依赖项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>() where T : class;

        /// <summary>
        /// 解析依赖项
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// 解析依赖项列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> ResolveAll<T>();

        /// <summary>
        /// 解析未注册的依赖项
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object ResolveUnregistered(Type type);

    }
}

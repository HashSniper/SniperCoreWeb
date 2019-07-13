using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sniper.Core.Configuration;
using Sniper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework.Infrastructure.Extensions
{
    public static class DbContextOptionsBuilderExtensions
    {
        /// <summary>
        /// 设置数据库模式
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <param name="services"></param>
        public static void UseSqlServerWithLazyLoading(this DbContextOptionsBuilder optionsBuilder, IServiceCollection services)
        {
            var nopConfig = services.BuildServiceProvider().GetRequiredService<NopConfig>();

            var dataSettings = DataSettingsManager.LoadSettings();

            if (!dataSettings?.IsValid ?? true)
            {
                return;
            }

            var dbContextOptionsBuilder = optionsBuilder.UseLazyLoadingProxies();

            if (nopConfig.UseRowNumberForPaging)
                dbContextOptionsBuilder.UseSqlServer(dataSettings.DataConnectionString, option => option.UseRowNumberForPaging());
            else
                dbContextOptionsBuilder.UseSqlServer(dataSettings.DataConnectionString);
        }
    }
}

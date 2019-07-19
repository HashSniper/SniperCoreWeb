using Sniper.Core.Domain.Customers;
using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Directory
{
    public partial interface IExchangeRatePluginManager : IPluginManager<IExchangeRateProvider>
    {
        /// <summary>
        /// 加载主要活跃汇率提供商
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        IExchangeRateProvider LoadPrimaryPlugin(Customer customer = null, int storeId = 0);

        /// <summary>
        /// 检查汇率提供商是否有效
        /// </summary>
        /// <param name="exchangeRateProvider"></param>
        /// <returns></returns>
        bool IsPluginActive(IExchangeRateProvider exchangeRateProvider);

    }
}

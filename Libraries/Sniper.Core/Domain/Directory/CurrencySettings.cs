using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Directory
{
    public class CurrencySettings : ISettings
    {
        /// <summary>
        /// 是否显示货币标签
        /// </summary>
        public bool DisplayCurrencyLabel { get; set; }

        /// <summary>
        /// 主要商店货币标识符
        /// </summary>
        public int PrimaryStoreCurrencyId { get; set; }

        /// <summary>
        /// 主要汇率货币标识符
        /// </summary>
        public int PrimaryExchangeRateCurrencyId { get; set; }

        /// <summary>
        /// 活跃汇率提供商系统名称（插件）
        /// </summary>
        public string ActiveExchangeRateProviderSystemName { get; set; }

        /// <summary>
        /// 是否启用自动货币汇率更新
        /// </summary>
        public bool AutoUpdateEnabled { get; set; }

    }
}

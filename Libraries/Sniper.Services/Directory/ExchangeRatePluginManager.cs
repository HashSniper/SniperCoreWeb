using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Directory;
using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Directory
{
    public partial class ExchangeRatePluginManager : PluginManager<IExchangeRateProvider>, IExchangeRatePluginManager
    {
        #region Fields

        private readonly CurrencySettings _currencySettings;

        #endregion

        #region Ctor

        public ExchangeRatePluginManager(CurrencySettings currencySettings,
            IPluginService pluginService) : base(pluginService)
        {
            _currencySettings = currencySettings;
        }

        #endregion

        #region Methods
        public bool IsPluginActive(IExchangeRateProvider exchangeRateProvider)
        {
            throw new NotImplementedException();
        }

        public IExchangeRateProvider LoadPrimaryPlugin(Customer customer = null, int storeId = 0)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

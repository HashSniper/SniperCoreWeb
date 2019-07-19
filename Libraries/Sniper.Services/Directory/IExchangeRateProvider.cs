using Sniper.Core.Domain.Directory;
using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Directory
{
    public partial interface IExchangeRateProvider : IPlugin
    {
        IList<ExchangeRate> GetCurrencyLiveRates(string exchangeRateCurrencyCode);

    }
}

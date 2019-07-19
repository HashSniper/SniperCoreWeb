using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Directory;
using Sniper.Services.Events;
using Sniper.Services.Stores;

namespace Sniper.Services.Directory
{
    public partial class CurrencyService : ICurrencyService
    {
        #region Fields
        private readonly CurrencySettings _currencySettings;
        private readonly IEventPublisher _eventPublisher;
        private readonly IExchangeRatePluginManager _exchangeRatePluginManager;
        private readonly IRepository<Currency> _currencyRepository;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreMappingService _storeMappingService;
        #endregion

        #region Ctor
        public CurrencyService(CurrencySettings currencySettings,
           IEventPublisher eventPublisher,
           IExchangeRatePluginManager exchangeRatePluginManager,
           IRepository<Currency> currencyRepository,
           IStaticCacheManager cacheManager,
           IStoreMappingService storeMappingService)
        {
            _currencySettings = currencySettings;
            _eventPublisher = eventPublisher;
            _exchangeRatePluginManager = exchangeRatePluginManager;
            _currencyRepository = currencyRepository;
            _cacheManager = cacheManager;
            _storeMappingService = storeMappingService;
        }
        #endregion

        #region Methods
        public decimal ConvertCurrency(decimal amount, decimal exchangeRate)
        {
            throw new NotImplementedException();
        }

        public decimal ConvertCurrency(decimal amount, Currency sourceCurrencyCode, Currency targetCurrencyCode)
        {
            throw new NotImplementedException();
        }

        public decimal ConvertFromPrimaryExchangeRateCurrency(decimal amount, Currency targetCurrencyCode)
        {
            throw new NotImplementedException();
        }

        public decimal ConvertFromPrimaryStoreCurrency(decimal amount, Currency targetCurrencyCode)
        {
            throw new NotImplementedException();
        }

        public decimal ConvertToPrimaryExchangeRateCurrency(decimal amount, Currency sourceCurrencyCode)
        {
            throw new NotImplementedException();
        }

        public decimal ConvertToPrimaryStoreCurrency(decimal amount, Currency sourceCurrencyCode)
        {
            throw new NotImplementedException();
        }

        public void DeleteCurrency(Currency currency)
        {
            throw new NotImplementedException();
        }

        public IList<Currency> GetAllCurrencies(bool showHidden = false, int storeId = 0, bool loadCacheableCopy = true)
        {
            throw new NotImplementedException();
        }

        public Currency GetCurrencyByCode(string currencyCode, bool loadCacheableCopy = true)
        {
            throw new NotImplementedException();
        }

        public Currency GetCurrencyById(int currencyId, bool loadCacheableCopy = true)
        {
            throw new NotImplementedException();
        }

        public IList<ExchangeRate> GetCurrencyLiveRates(string currencyCode = null)
        {
            throw new NotImplementedException();
        }

        public void InsertCurrency(Currency currency)
        {
            throw new NotImplementedException();
        }

        public void UpdateCurrency(Currency currency)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Directory;
using Sniper.Core.Domain.Stores;
using Sniper.Services.Events;
using Sniper.Services.Localization;

namespace Sniper.Services.Directory
{
    public partial class CountryService : ICountryService
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<StoreMapping> _storeMappingRepository;
        private readonly IStoreContext _storeContext;

        #endregion

        #region Ctor

        public CountryService(CatalogSettings catalogSettings,
            ICacheManager cacheManager,
            IEventPublisher eventPublisher,
            ILocalizationService localizationService,
            IRepository<Country> countryRepository,
            IRepository<StoreMapping> storeMappingRepository,
            IStoreContext storeContext)
        {
            _catalogSettings = catalogSettings;
            _cacheManager = cacheManager;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _countryRepository = countryRepository;
            _storeMappingRepository = storeMappingRepository;
            _storeContext = storeContext;
        }

        #endregion


        #region Methods
        public void DeleteCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public IList<Country> GetAllCountries(int languageId = 0, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public IList<Country> GetAllCountriesForBilling(int languageId = 0, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public IList<Country> GetAllCountriesForShipping(int languageId = 0, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public IList<Country> GetCountriesByIds(int[] countryIds)
        {
            throw new NotImplementedException();
        }

        public Country GetCountryById(int countryId)
        {
            throw new NotImplementedException();
        }

        public Country GetCountryByThreeLetterIsoCode(string threeLetterIsoCode)
        {
            throw new NotImplementedException();
        }

        public Country GetCountryByTwoLetterIsoCode(string twoLetterIsoCode)
        {
            throw new NotImplementedException();
        }

        public void InsertCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public void UpdateCountry(Country country)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

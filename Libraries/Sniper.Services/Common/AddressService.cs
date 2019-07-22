using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Common;
using Sniper.Services.Directory;
using Sniper.Services.Events;

namespace Sniper.Services.Common
{
    public partial class AddressService : IAddressService
    {
        #region Fields

        private readonly AddressSettings _addressSettings;
        private readonly IAddressAttributeParser _addressAttributeParser;
        private readonly IAddressAttributeService _addressAttributeService;
        private readonly ICacheManager _cacheManager;
        private readonly ICountryService _countryService;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<Address> _addressRepository;
        private readonly IStateProvinceService _stateProvinceService;

        #endregion

        #region Ctor

        public AddressService(AddressSettings addressSettings,
            IAddressAttributeParser addressAttributeParser,
            IAddressAttributeService addressAttributeService,
            ICacheManager cacheManager,
            ICountryService countryService,
            IEventPublisher eventPublisher,
            IRepository<Address> addressRepository,
            IStateProvinceService stateProvinceService)
        {
            _addressSettings = addressSettings;
            _addressAttributeParser = addressAttributeParser;
            _addressAttributeService = addressAttributeService;
            _cacheManager = cacheManager;
            _countryService = countryService;
            _eventPublisher = eventPublisher;
            _addressRepository = addressRepository;
            _stateProvinceService = stateProvinceService;
        }

        #endregion

        #region Methods
        public void DeleteAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Address FindAddress(List<Address> source, string firstName, string lastName, string phoneNumber, string email, string faxNumber, string company, string address1, string address2, string city, string county, int? stateProvinceId, string zipPostalCode, int? countryId, string customAttributes)
        {
            throw new NotImplementedException();
        }

        public Address GetAddressById(int addressId)
        {
            throw new NotImplementedException();
        }

        public int GetAddressTotalByCountryId(int countryId)
        {
            throw new NotImplementedException();
        }

        public int GetAddressTotalByStateProvinceId(int stateProvinceId)
        {
            throw new NotImplementedException();
        }

        public void InsertAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public bool IsAddressValid(Address address)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddress(Address address)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

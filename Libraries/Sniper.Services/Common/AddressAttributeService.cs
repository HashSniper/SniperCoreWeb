using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Common;
using Sniper.Services.Events;

namespace Sniper.Services.Common
{
    public partial class AddressAttributeService : IAddressAttributeService
    {
        #region Fields

        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<AddressAttribute> _addressAttributeRepository;
        private readonly IRepository<AddressAttributeValue> _addressAttributeValueRepository;

        #endregion

        #region Ctor

        public AddressAttributeService(ICacheManager cacheManager,
            IEventPublisher eventPublisher,
            IRepository<AddressAttribute> addressAttributeRepository,
            IRepository<AddressAttributeValue> addressAttributeValueRepository)
        {
            _cacheManager = cacheManager;
            _eventPublisher = eventPublisher;
            _addressAttributeRepository = addressAttributeRepository;
            _addressAttributeValueRepository = addressAttributeValueRepository;
        }

        #endregion

        #region Methods
        public void DeleteAddressAttribute(AddressAttribute addressAttribute)
        {
            throw new NotImplementedException();
        }

        public void DeleteAddressAttributeValue(AddressAttributeValue addressAttributeValue)
        {
            throw new NotImplementedException();
        }

        public AddressAttribute GetAddressAttributeById(int addressAttributeId)
        {
            throw new NotImplementedException();
        }

        public AddressAttributeValue GetAddressAttributeValueById(int addressAttributeValueId)
        {
            throw new NotImplementedException();
        }

        public IList<AddressAttributeValue> GetAddressAttributeValues(int addressAttributeId)
        {
            throw new NotImplementedException();
        }

        public IList<AddressAttribute> GetAllAddressAttributes()
        {
            throw new NotImplementedException();
        }

        public void InsertAddressAttribute(AddressAttribute addressAttribute)
        {
            throw new NotImplementedException();
        }

        public void InsertAddressAttributeValue(AddressAttributeValue addressAttributeValue)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddressAttribute(AddressAttribute addressAttribute)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddressAttributeValue(AddressAttributeValue addressAttributeValue)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

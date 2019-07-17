using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Stores;
using Sniper.Services.Events;

namespace Sniper.Services.Stores
{
    public partial class StoreMappingService : IStoreMappingService
    {
        #region Fileds
        private readonly CatalogSettings _catalogSettings;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<StoreMapping> _storeMappingRepository;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreContext _storeContext;

        #endregion

        #region Ctor
        public StoreMappingService(CatalogSettings catalogSettings,
           IEventPublisher eventPublisher,
           IRepository<StoreMapping> storeMappingRepository,
           IStaticCacheManager cacheManager,
           IStoreContext storeContext)
        {
            _catalogSettings = catalogSettings;
            _eventPublisher = eventPublisher;
            _storeMappingRepository = storeMappingRepository;
            _cacheManager = cacheManager;
            _storeContext = storeContext;
        }
        #endregion

        #region Methods
        public bool Authorize<T>(T entity) where T : BaseEntity, IStoreMappingSupported
        {
            throw new NotImplementedException();
        }

        public bool Authorize<T>(T entity, int storeId) where T : BaseEntity, IStoreMappingSupported
        {
            throw new NotImplementedException();
        }

        public void DeleteStoreMapping(StoreMapping storeMapping)
        {
            throw new NotImplementedException();
        }

        public StoreMapping GetStoreMappingById(int storeMappingId)
        {
            throw new NotImplementedException();
        }

        public IList<StoreMapping> GetStoreMappings<T>(T entity) where T : BaseEntity, IStoreMappingSupported
        {
            throw new NotImplementedException();
        }

        public int[] GetStoresIdsWithAccess<T>(T entity) where T : BaseEntity, IStoreMappingSupported
        {
            throw new NotImplementedException();
        }

        public void InsertStoreMapping<T>(T entity, int storeId) where T : BaseEntity, IStoreMappingSupported
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

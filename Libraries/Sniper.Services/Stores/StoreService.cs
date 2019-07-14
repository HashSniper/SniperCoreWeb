using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Stores;
using Sniper.Services.Events;
using System.Linq;

namespace Sniper.Services.Stores
{
    public partial class StoreService : IStoreService
    {
        #region Fileds
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<Store> _storeRepository;
        private readonly IStaticCacheManager _cacheManager;

        #endregion

        #region ctor
        public StoreService(IEventPublisher eventPublisher, IRepository<Store> storeRepository, IStaticCacheManager cacheManager)
        {
            _eventPublisher = eventPublisher;
            _storeRepository = storeRepository;
            _cacheManager = cacheManager;
        }
        #endregion

        #region Methods
        public virtual bool ContainsHostValue(Store store, string host)
        {
            if(store==null)
                throw new ArgumentNullException(nameof(store));
            if (string.IsNullOrEmpty(host))
                return false;

            var contains = ParseHostValues(store).Any(x => x.Equals(host, StringComparison.InvariantCultureIgnoreCase));
            return contains;
        }

        public void DeleteStore(Store store)
        {
            throw new NotImplementedException();
        }

        public virtual IList<Store> GetAllStores(bool loadCacheableCopy = true)
        {
            IList<Store> LoadStoresFunc()
            {
                var query = from s in _storeRepository.Table orderby s.DisplayOrder, s.Id select s;
                return query.ToList();
            }
            if (loadCacheableCopy)
            {
                return _cacheManager.Get(NopStoreDefaults.StoresAllCacheKey, () =>
                {
                    var result = new List<Store>();
                    foreach (var store in LoadStoresFunc())
                    {
                        result.Add(new StoreForCaching(store));
                    }
                    return result;
                });
            }

            return LoadStoresFunc();
        }

        public string[] GetNotExistingStores(string[] storeIdsNames)
        {
            throw new NotImplementedException();
        }

        public Store GetStoreById(int storeId, bool loadCacheableCopy = true)
        {
            throw new NotImplementedException();
        }

        public void InsertStore(Store store)
        {
            throw new NotImplementedException();
        }

        public string[] ParseHostValues(Store store)
        {
            if (store == null)
                throw new ArgumentNullException(nameof(store));

            var parsedValues = new List<string>();

            if (string.IsNullOrEmpty(store.Hosts))
            {
                return parsedValues.ToArray();
            }

            var hosts = store.Hosts.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var host in hosts)
            {
                var tmp = host.Trim();

                if (!string.IsNullOrEmpty(tmp))
                {
                    parsedValues.Add(tmp);
                }
            }

            return parsedValues.ToArray();
        }

        public void UpdateStore(Store store)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

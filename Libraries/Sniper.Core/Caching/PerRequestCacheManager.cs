using Microsoft.AspNetCore.Http;
using Sniper.Core.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sniper.Core.Caching
{
    public partial class PerRequestCacheManager : ICacheManager
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ReaderWriterLockSlim _locker;

        #endregion

        #region Ctor

        public PerRequestCacheManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            _locker = new ReaderWriterLockSlim();
        }

        #endregion

        #region Methods
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public virtual T Get<T>(string key, Func<T> acquire, int? cacheTime = null)
        {
            IDictionary<object, object> items;

            using (new ReaderWriteLockDisposable(_locker, ReaderWriteLokeType.Read))
            {
                items = GetItems();

                if (items == null)
                    return acquire();

                if (items[key] != null)
                {
                    return (T)items[key];
                }
            }

            var result = acquire();

            if (result == null || (cacheTime ?? NopCachingDefaults.CacheTime) <= 0)
                return result;

            using (new ReaderWriteLockDisposable(_locker))
            {
                items[key] = result;
            }

            return result;
        }

        public bool IsSet(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveByPrefix(string prefix)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object data, int cacheTime)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Utilities

        protected virtual IDictionary<object, object> GetItems()
        {
            return _httpContextAccessor.HttpContext?.Items;
        }

        #endregion
    }
}

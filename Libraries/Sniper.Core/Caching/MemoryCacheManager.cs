using EasyCaching.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sniper.Core.Caching
{
    public partial class MemoryCacheManager : ILocker, IStaticCacheManager
    {
        #region Fileds
        private readonly IEasyCachingProvider _provider;
        #endregion

        #region Ctor
        public MemoryCacheManager(IEasyCachingProvider provider)
        {
            _provider = provider;
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

        /// <summary>
        /// 加载缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="acquire"></param>
        /// <param name="cacheTime"></param>
        /// <returns></returns>
        public T Get<T>(string key, Func<T> acquire, int? cacheTime = null)
        {
            if (cacheTime <= 0)
                return acquire();

            return _provider.Get(key, acquire, TimeSpan.FromMinutes(cacheTime ?? NopCachingDefaults.CacheTime)).Value;
        }

        public Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, int? cacheTime = null)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取一个值，该值指示是否缓存与指定键关联的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsSet(string key)
        {
            return _provider.Exists(key);
        }

        public bool PerformActionWithLock(string resource, TimeSpan expirationTime, Action action)
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sniper.Core.Caching
{
    public interface IStaticCacheManager: ICacheManager
    {
        /// <summary>
        /// 获取缓存项目。 如果它还没有在缓存中，则加载并缓存它
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="acquire"></param>
        /// <param name="cacheTime"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, int? cacheTime = null);

    }
}

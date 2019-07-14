using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Caching
{
    public interface ICacheManager : IDisposable
    {
        /// <summary>
        /// 获取缓存项目。 如果它还没有在缓存中，则加载并缓存它
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="acquire"></param>
        /// <param name="cacheTime"></param>
        /// <returns></returns>
        T Get<T>(string key, Func<T> acquire, int? cacheTime = null);

        /// <summary>
        /// 将指定的键和对象添加到缓存中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime"></param>
        void Set(string key, object data, int cacheTime);

        /// <summary>
        /// 获取一个值，该值指示是否缓存与指定键关联的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsSet(string key);

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// 按键前缀删除项目
        /// </summary>
        /// <param name="prefix"></param>
        void RemoveByPrefix(string prefix);

        /// <summary>
        /// 清除缓存
        /// </summary>
        void Clear();

    }
}

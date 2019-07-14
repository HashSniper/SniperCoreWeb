using Sniper.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Stores
{
    public interface IStoreService
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="store"></param>
        void DeleteStore(Store store);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="loadCacheableCopy"></param>
        /// <returns></returns>
        IList<Store> GetAllStores(bool loadCacheableCopy = true);

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="loadCacheableCopy"></param>
        /// <returns></returns>
        Store GetStoreById(int storeId, bool loadCacheableCopy = true);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="store"></param>
        void InsertStore(Store store);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="store"></param>
        void UpdateStore(Store store);

        /// <summary>
        /// 解析主机
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        string[] ParseHostValues(Store store);

        /// <summary>
        /// 是否包含主机
        /// </summary>
        /// <param name="store"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        bool ContainsHostValue(Store store, string host);

        /// <summary>
        /// 返回不包含列表
        /// </summary>
        /// <param name="storeIdsNames"></param>
        /// <returns></returns>
        string[] GetNotExistingStores(string[] storeIdsNames);



    }
}

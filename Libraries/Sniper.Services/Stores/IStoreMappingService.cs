using Sniper.Core;
using Sniper.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Stores
{
    public partial interface IStoreMappingService
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="storeMapping"></param>
        void DeleteStoreMapping(StoreMapping storeMapping);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="storeMappingId"></param>
        /// <returns></returns>
        StoreMapping GetStoreMappingById(int storeMappingId);

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        IList<StoreMapping> GetStoreMappings<T>(T entity) where T : BaseEntity, IStoreMappingSupported;

        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="storeId"></param>
        void InsertStoreMapping<T>(T entity, int storeId) where T : BaseEntity, IStoreMappingSupported;

        /// <summary>
        /// 查找具有授予访问权限的商店标识符（映射到实体）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        int[] GetStoresIdsWithAccess<T>(T entity) where T : BaseEntity, IStoreMappingSupported;

        /// <summary>
        /// 授权是否可以在当前商店中访问实体（映射到此商店）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Authorize<T>(T entity) where T : BaseEntity, IStoreMappingSupported;

        /// <summary>
        ///  Authorize whether entity could be accessed in a store (mapped to this store)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        bool Authorize<T>(T entity, int storeId) where T : BaseEntity, IStoreMappingSupported;

    }
}

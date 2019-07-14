using Sniper.Core;
using Sniper.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Common
{
    public partial interface  IGenericAttributeService
    {
        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="attribute"></param>
        void DeleteAttribute(GenericAttribute attribute);

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="attributes"></param>
        void DeleteAttributes(IList<GenericAttribute> attributes);

        /// <summary>
        /// 根据id获取节点
        /// </summary>
        /// <param name="attributeId"></param>
        /// <returns></returns>
        GenericAttribute GetAttributeById(int attributeId);

        /// <summary>
        /// 插入节点
        /// </summary>
        /// <param name="attribute"></param>
        void InsertAttribute(GenericAttribute attribute);

        /// <summary>
        /// 更新节点
        /// </summary>
        /// <param name="attribute"></param>
        void UpdateAttribute(GenericAttribute attribute);

        /// <summary>
        /// 获取节点
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="keyGroup"></param>
        /// <returns></returns>
        IList<GenericAttribute> GetAttributesForEntity(int entityId, string keyGroup);

        /// <summary>
        /// 保存节点
        /// </summary>
        /// <typeparam name="TPropType"></typeparam>
        /// <param name="entity"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="storeId"></param>
        void SaveAttribute<TPropType>(BaseEntity entity, string key, TPropType value, int storeId = 0);

        /// <summary>
        /// 获取实体的属性
        /// </summary>
        /// <typeparam name="TPropType"></typeparam>
        /// <param name="entity"></param>
        /// <param name="key"></param>
        /// <param name="storeId"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        TPropType GetAttribute<TPropType>(BaseEntity entity, string key, int storeId = 0, TPropType defaultValue = default(TPropType));

    }
}

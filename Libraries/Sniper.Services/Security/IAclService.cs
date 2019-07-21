using Sniper.Core;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Security
{
    /// <summary>
    /// ACL服务接口
    /// </summary>
    public partial interface IAclService
    {
        /// <summary>
        /// 删除acl记录
        /// </summary>
        /// <param name="aclRecord"></param>
        void DeleteAclRecord(AclRecord aclRecord);

        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="aclRecordId"></param>
        /// <returns></returns>
        AclRecord GetAclRecordById(int aclRecordId);

        /// <summary>
        /// 获取记录列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        IList<AclRecord> GetAclRecords<T>(T entity) where T : BaseEntity, IAclSupported;

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="aclRecord"></param>
        void InsertAclRecord(AclRecord aclRecord);

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="customerRoleId"></param>
        void InsertAclRecord<T>(T entity, int customerRoleId) where T : BaseEntity, IAclSupported;

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="aclRecord"></param>
        void UpdateAclRecord(AclRecord aclRecord);

        /// <summary>
        /// 查找已授予访问权限的客户角色标识
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        int[] GetCustomerRoleIdsWithAccess<T>(T entity) where T : BaseEntity, IAclSupported;

        /// <summary>
        /// 授权ACL权限
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Authorize<T>(T entity) where T : BaseEntity, IAclSupported;

        /// <summary>
        /// 授权ACL权限
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        bool Authorize<T>(T entity, Customer customer) where T : BaseEntity, IAclSupported;

    }
}

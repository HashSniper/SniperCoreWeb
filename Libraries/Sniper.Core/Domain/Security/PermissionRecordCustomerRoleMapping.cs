using Sniper.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Security
{
    public partial class PermissionRecordCustomerRoleMapping:BaseEntity
    {
        /// <summary>
        /// 获取或设置权限记录标识符
        /// </summary>
        public int PermissionRecordId { get; set; }

        /// <summary>
        /// 客户角色标识符
        /// </summary>
        public int CustomerRoleId { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public virtual PermissionRecord PermissionRecord { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual CustomerRole CustomerRole { get; set; }
    }
}

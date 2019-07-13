using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Security
{
    public partial class PermissionRecord:BaseEntity
    {
        private ICollection<PermissionRecordCustomerRoleMapping> _permissionRecordCustomerRoleMappings;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 权限类别
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 权限记录 - 客户角色映射
        /// </summary>
        public virtual ICollection<PermissionRecordCustomerRoleMapping> PermissionRecordCustomerRoleMappings
        {
            get => _permissionRecordCustomerRoleMappings ?? (_permissionRecordCustomerRoleMappings = new List<PermissionRecordCustomerRoleMapping>());
            protected set => _permissionRecordCustomerRoleMappings = value;
        }
    }
}

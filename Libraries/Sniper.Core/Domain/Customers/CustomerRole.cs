using Sniper.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Customers
{
    public partial class CustomerRole : BaseEntity
    {
        private ICollection<PermissionRecordCustomerRoleMapping> _permissionRecordCustomerRoleMappings;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 客户角色是否标记为免费送货
        /// </summary>
        public bool FreeShipping { get; set; }

        /// <summary>
        /// 指示客户角色是否标记为免税
        /// </summary>
        public bool TaxExempt { get; set; }

        /// <summary>
        /// 客户是否处于活跃状态
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 客户为系统角色
        /// </summary>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 客户是否必须在指定时间后更改密码
        /// </summary>
        public bool EnablePasswordLifetime { get; set; }

        /// <summary>
        /// 角色的客户是否选择了其他税制显示类型而不是默认值
        /// </summary>
        public bool OverrideTaxDisplayType { get; set; }

        /// <summary>
        /// 默认税制显示类型的标识符（仅在启用“OverrideTaxDisplayType”时使用）
        /// </summary>
        public int DefaultTaxDisplayTypeId { get; set; }

        /// <summary>
        /// 客户角色所需的产品标识符。
        /// </summary>
        public int PurchasedWithProductId { get; set; }

        /// <summary>
        /// 客户角色映射
        /// </summary>
        public virtual ICollection<PermissionRecordCustomerRoleMapping> PermissionRecordCustomerRoleMappings
        {
            get => _permissionRecordCustomerRoleMappings ?? (_permissionRecordCustomerRoleMappings = new List<PermissionRecordCustomerRoleMapping>());
            protected set => _permissionRecordCustomerRoleMappings = value;
        }
    }
}

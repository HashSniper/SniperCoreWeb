using Sniper.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Security
{
    /// <summary>
    /// 表示ACL记录
    /// </summary>
    public partial class AclRecord : BaseEntity
    {
        /// <summary>
        /// 实体标识符
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// 实体名称
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// 客户角色标识符
        /// </summary>
        public int CustomerRoleId { get; set; }

        /// <summary>
        /// 客户角色
        /// </summary>
        public virtual CustomerRole CustomerRole { get; set; }



    }
}

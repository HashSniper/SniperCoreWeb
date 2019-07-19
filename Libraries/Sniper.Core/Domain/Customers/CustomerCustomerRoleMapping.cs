using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Customers
{
    public partial class CustomerCustomerRoleMapping : BaseEntity
    {
        /// <summary>
        /// 客户标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 客户角色标识符
        /// </summary>
        public int CustomerRoleId { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 客户角色
        /// </summary>
        public virtual CustomerRole CustomerRole { get; set; }

    }
}

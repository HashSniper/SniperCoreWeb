using Sniper.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Customers
{
    /// <summary>
    /// 表示客户地址映射类
    /// </summary>
    public partial class CustomerAddressMapping : BaseEntity
    {
        /// <summary>
        /// 顾客标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 地址标识符
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// 顾客
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual Address Address { get; set; }

    }
}

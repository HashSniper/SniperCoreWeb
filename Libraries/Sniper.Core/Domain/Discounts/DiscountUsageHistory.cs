using Sniper.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Discounts
{
    /// <summary>
    /// 表示折扣使用历史记录条目
    /// </summary>
    public partial class DiscountUsageHistory : BaseEntity
    {

        /// <summary>
        /// 折扣标识符
        /// </summary>
        public int DiscountId { get; set; }

        /// <summary>
        /// 订单标识符
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public virtual Discount Discount { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        public virtual Order Order { get; set; }

    }
}

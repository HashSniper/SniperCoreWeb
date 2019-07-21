using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Orders
{
    /// <summary>
    /// 表示礼品卡使用历史记录条目
    /// </summary>
    public partial class GiftCardUsageHistory : BaseEntity
    {
        /// <summary>
        /// 礼品卡标识符
        /// </summary>
        public int GiftCardId { get; set; }

        /// <summary>
        /// 订单标识符
        /// </summary>
        public int UsedWithOrderId { get; set; }

        /// <summary>
        /// 使用价值（金额）
        /// </summary>
        public decimal UsedValue { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 礼品卡
        /// </summary>
        public virtual GiftCard GiftCard { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        public virtual Order UsedWithOrder { get; set; }

    }
}

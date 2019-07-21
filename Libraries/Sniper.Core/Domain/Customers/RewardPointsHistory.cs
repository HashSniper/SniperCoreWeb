using Sniper.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Customers
{
    /// <summary>
    /// 表示奖励积分历史记录条目
    /// </summary>
    public partial class RewardPointsHistory : BaseEntity
    {
        /// <summary>
        /// 顾客标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 商店标识符
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 积分兑换/补充
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// 积分平衡
        /// </summary>
        public int? PointsBalance { get; set; }

        /// <summary>
        /// 使用量
        /// </summary>
        public decimal UsedAmount { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// 尚未花费的有效积分数（仅适用于正积分）
        /// </summary>
        public int? ValidPoints { get; set; }

        /// <summary>
        /// 积分兑换为付款的顺序（客户在下订单时花费）
        /// </summary>
        public virtual Order UsedWithOrder { get; set; }

        /// <summary>
        /// 顾客
        /// </summary>
        public virtual Customer Customer { get; set; }

    }
}

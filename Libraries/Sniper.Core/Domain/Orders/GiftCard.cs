using Sniper.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Orders
{
    /// <summary>
    /// 礼品卡
    /// </summary>
    public partial class GiftCard : BaseEntity
    {
        private ICollection<GiftCardUsageHistory> _giftCardUsageHistory;

        /// <summary>
        /// 关联的订单商品标识符
        /// </summary>
        public int? PurchasedWithOrderItemId { get; set; }

        /// <summary>
        /// 礼品卡标识符
        /// </summary>
        public int GiftCardTypeId { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsGiftCardActivated { get; set; }

        /// <summary>
        /// 礼品卡优惠券代码
        /// </summary>
        public string GiftCardCouponCode { get; set; }

        /// <summary>
        /// 收件人姓名
        /// </summary>
        public string RecipientName { get; set; }

        /// <summary>
        /// 收件人邮箱
        /// </summary>
        public string RecipientEmail { get; set; }

        /// <summary>
        /// 发件人姓名
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// 发件人邮箱
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// 是否通知收件人
        /// </summary>
        public bool IsRecipientNotified { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 礼品卡类型
        /// </summary>
        public GiftCardType GiftCardType
        {
            get => (GiftCardType)GiftCardTypeId;
            set => GiftCardTypeId = (int)value;
        }

        /// <summary>
        /// 使用记录
        /// </summary>
        public virtual ICollection<GiftCardUsageHistory> GiftCardUsageHistory
        {
            get => _giftCardUsageHistory ?? (_giftCardUsageHistory = new List<GiftCardUsageHistory>());
            protected set => _giftCardUsageHistory = value;
        }

        /// <summary>
        /// 关联的订单商品
        /// </summary>
        public virtual OrderItem PurchasedWithOrderItem { get; set; }

    }
}

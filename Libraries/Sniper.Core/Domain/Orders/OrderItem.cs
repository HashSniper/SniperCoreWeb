using Sniper.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Orders
{
    /// <summary>
    /// 表示订单商品
    /// </summary>
    public partial class OrderItem : BaseEntity
    {
        private ICollection<GiftCard> _associatedGiftCards;

        /// <summary>
        /// 订单商品guid
        /// </summary>
        public Guid OrderItemGuid { get; set; }

        /// <summary>
        /// 订单商品标识符
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 产品标识符
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 主要商店货币的单价（含税）
        /// </summary>
        public decimal UnitPriceInclTax { get; set; }

        /// <summary>
        /// 主要商店货币的单价（不含税）
        /// </summary>
        public decimal UnitPriceExclTax { get; set; }

        /// <summary>
        /// 主要商店货币的价格（含税）
        /// </summary>
        public decimal PriceInclTax { get; set; }

        /// <summary>
        /// 主要商店货币的价格（不含税）
        /// </summary>
        public decimal PriceExclTax { get; set; }

        /// <summary>
        /// 折扣金额（含税）
        /// </summary>
        public decimal DiscountAmountInclTax { get; set; }

        /// <summary>
        /// 折扣金额（不含税）
        /// </summary>
        public decimal DiscountAmountExclTax { get; set; }

        /// <summary>
        /// 此订单商品的原始成本（下订单时），数量1
        /// </summary>
        public decimal OriginalProductCost { get; set; }

        /// <summary>
        /// 属性描述
        /// </summary>
        public string AttributeDescription { get; set; }

        /// <summary>
        /// 属性xml
        /// </summary>
        public string AttributesXml { get; set; }

        /// <summary>
        /// 下载次数
        /// </summary>
        public int DownloadCount { get; set; }

        /// <summary>
        /// 是否已激活下载
        /// </summary>
        public bool IsDownloadActivated { get; set; }

        /// <summary>
        /// 许可证下载标识符（如果这是可下载的产品）
        /// </summary>
        public int? LicenseDownloadId { get; set; }

        /// <summary>
        /// 获取或设置一个项目的总重量
        /// </summary>
        public decimal? ItemWeight { get; set; }

        /// <summary>
        /// 租赁产品的开始日期（如果不是租赁产品，则为null）
        /// </summary>
        public DateTime? RentalStartDateUtc { get; set; }

        /// <summary>
        /// 租赁产品的结束日期
        /// </summary>
        public DateTime? RentalEndDateUtc { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Product Product { get; set; }

        public virtual ICollection<GiftCard> AssociatedGiftCards
        {
            get => _associatedGiftCards ?? (_associatedGiftCards = new List<GiftCard>());
            protected set => _associatedGiftCards = value;
        }

    }
}

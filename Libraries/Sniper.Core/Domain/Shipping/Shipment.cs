using Sniper.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Shipping
{
    public partial class Shipment : BaseEntity
    {
        private ICollection<ShipmentItem> _shipmentItems;

        /// <summary>
        /// OrderId
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 这批货物的追踪号码
        /// </summary>
        public string TrackingNumber { get; set; }

        /// <summary>
        /// 总重量
        /// </summary>
        public decimal? TotalWeight { get; set; }

        /// <summary>
        /// 发货日期和时间
        /// </summary>
        public DateTime? ShippedDateUtc { get; set; }

        /// <summary>
        /// 交货日期和时间
        /// </summary>
        public DateTime? DeliveryDateUtc { get; set; }

        /// <summary>
        /// 管理员评论
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<ShipmentItem> ShipmentItems
        {
            get => _shipmentItems ?? (_shipmentItems = new List<ShipmentItem>());
            protected set => _shipmentItems = value;
        }
    }
}

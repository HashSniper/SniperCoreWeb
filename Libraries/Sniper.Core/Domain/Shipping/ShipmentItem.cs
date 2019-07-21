using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Shipping
{
    /// <summary>
    /// 表示装运项目
    /// </summary>
    public partial class ShipmentItem : BaseEntity
    {
        /// <summary>
        /// 货件标识符
        /// </summary>
        public int ShipmentId { get; set; }

        /// <summary>
        /// 订单商品标识符
        /// </summary>
        public int OrderItemId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 仓库标识符
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 运输
        /// </summary>
        public virtual Shipment Shipment { get; set; }

    }
}

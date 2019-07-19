using Sniper.Core.Domain.Shipping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    public partial class ProductWarehouseInventory : BaseEntity
    {
        /// <summary>
        /// 产品标识符
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 仓库标识符
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// 保留数量（订购但尚未发货）
        /// </summary>
        public int ReservedQuantity { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public virtual Warehouse Warehouse { get; set; }

    }
}

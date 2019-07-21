using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    public partial class StockQuantityHistory : BaseEntity
    {
        /// <summary>
        /// 库存量调整
        /// </summary>
        public int QuantityAdjustment { get; set; }

        /// <summary>
        /// 当前库存数量
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 产品标识符
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 产品属性组合标识符
        /// </summary>
        public int? CombinationId { get; set; }

        /// <summary>
        /// 仓库标识符
        /// </summary>
        public int? WarehouseId { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Product Product { get; set; }

    }
}

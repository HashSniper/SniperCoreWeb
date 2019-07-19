using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    /// <summary>
    /// 表示产品制造商映射
    /// </summary>
    public partial class ProductManufacturer : BaseEntity
    {
        /// <summary>
        /// 产品标识符
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 制造商标识符
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// 是否为特色产品
        /// </summary>
        public bool IsFeaturedProduct { get; set; }

        /// <summary>
        /// 展示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 制造商
        /// </summary>
        public virtual Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Product Product { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    /// <summary>
    /// 表示产品类别映射
    /// </summary>
    public partial class ProductCategory : BaseEntity
    {
        /// <summary>
        /// 产品标识符
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 类别标识符
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 是否为特色产品
        /// </summary>
        public bool IsFeaturedProduct { get; set; }

        /// <summary>
        /// 展示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Product Product { get; set; }

    }
}

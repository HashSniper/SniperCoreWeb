using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    public partial class ProductProductTagMapping : BaseEntity
    {
        /// <summary>
        /// 铲平标志符
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 产品标签标识符
        /// </summary>
        public int ProductTagId { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 产品标签
        /// </summary>
        public virtual ProductTag ProductTag { get; set; }

    }
}

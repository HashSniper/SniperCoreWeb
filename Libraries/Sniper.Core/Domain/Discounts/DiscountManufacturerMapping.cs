using Sniper.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Discounts
{
    public partial class DiscountManufacturerMapping : BaseEntity
    {
        /// <summary>
        /// 账号标识符
        /// </summary>
        public int DiscountId { get; set; }

        /// <summary>
        /// 制造商标识符
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public virtual Discount Discount { get; set; }

        /// <summary>
        /// 制造商
        /// </summary>
        public virtual Manufacturer Manufacturer { get; set; }

    }
}

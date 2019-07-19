using Sniper.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Discounts
{
    public partial class DiscountCategoryMapping : BaseEntity
    {
        /// <summary>
        /// 账号标识符
        /// </summary>
        public int DiscountId { get; set; }

        /// <summary>
        /// 类别标识符
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public virtual Discount Discount { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public virtual Category Category { get; set; }

    }
}

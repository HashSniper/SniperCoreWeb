using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Discounts
{
    public partial interface IDiscountSupported
    {
        /// <summary>
        /// Gets or sets the collection of applied discounts
        /// </summary>
        IList<Discount> AppliedDiscounts { get; }
    }
}

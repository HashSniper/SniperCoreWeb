using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Discounts
{
    public enum DiscountLimitationType
    {
        /// <summary>
        /// None
        /// </summary>
        Unlimited = 0,

        /// <summary>
        /// N Times Only
        /// </summary>
        NTimesOnly = 15,

        /// <summary>
        /// N Times Per Customer
        /// </summary>
        NTimesPerCustomer = 25
    }
}

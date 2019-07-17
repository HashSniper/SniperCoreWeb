using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Tax
{
    public enum TaxBasedOn
    {
        /// <summary>
        /// Billing address
        /// </summary>
        BillingAddress = 1,

        /// <summary>
        /// Shipping address
        /// </summary>
        ShippingAddress = 2,

        /// <summary>
        /// Default address
        /// </summary>
        DefaultAddress = 3
    }
}

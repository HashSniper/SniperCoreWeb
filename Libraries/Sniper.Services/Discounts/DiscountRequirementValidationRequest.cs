using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Discounts
{
    public partial class DiscountRequirementValidationRequest
    {
        /// <summary>
        /// Gets or sets the appropriate discount requirement ID (identifier)
        /// </summary>
        public int DiscountRequirementId { get; set; }

        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the store
        /// </summary>
        public Store Store { get; set; }
    }
}

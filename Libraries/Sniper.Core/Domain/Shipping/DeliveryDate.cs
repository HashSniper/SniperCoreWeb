using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Shipping
{
    public partial class DeliveryDate : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}

using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Shipping
{
    /// <summary>
    /// 表示产品可用性范围
    /// </summary>
    public partial class ProductAvailabilityRange : BaseEntity, ILocalizedEntity
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

using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    /// <summary>
    /// 表示预定义（默认）产品属性值
    /// </summary>
    public partial class PredefinedProductAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// Gets or sets the product attribute identifier
        /// </summary>
        public int ProductAttributeId { get; set; }

        /// <summary>
        /// Gets or sets the product attribute name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price adjustment
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "price adjustment" is specified as percentage
        /// </summary>
        public bool PriceAdjustmentUsePercentage { get; set; }

        /// <summary>
        /// Gets or sets the weight adjustment
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        /// Gets or sets the attribute value cost
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value is pre-selected
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets the product attribute
        /// </summary>
        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}

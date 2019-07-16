using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Shipping
{
    public partial class ShippingMethod : BaseEntity, ILocalizedEntity
    {
        private ICollection<ShippingMethodCountryMapping> _shippingMethodCountryMappings;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        public virtual ICollection<ShippingMethodCountryMapping> ShippingMethodCountryMappings
        {
            get => _shippingMethodCountryMappings ?? (_shippingMethodCountryMappings = new List<ShippingMethodCountryMapping>());
            protected set => _shippingMethodCountryMappings = value;
        }
    }
}

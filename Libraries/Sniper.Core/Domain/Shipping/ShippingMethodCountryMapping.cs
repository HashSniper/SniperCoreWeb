using Sniper.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Shipping
{
    public partial class ShippingMethodCountryMapping : BaseEntity
    {
        /// <summary>
        /// 送货方式标识符
        /// </summary>
        public int ShippingMethodId { get; set; }

        /// <summary>
        /// 国家编号
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// 送货途径
        /// </summary>
        public virtual ShippingMethod ShippingMethod { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public virtual Country Country { get; set; }

    }
}

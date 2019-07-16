using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Shipping;
using Sniper.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Directory
{
    public partial class Country : BaseEntity, ILocalizedEntity, IStoreMappingSupported
    {
        private ICollection<StateProvince> _stateProvinces;

        private ICollection<ShippingMethodCountryMapping> _shippingMethodCountryMappings;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否允许对此国家/地区进行结算
        /// </summary>
        public bool AllowsBilling { get; set; }

        /// <summary>
        /// 是否允许配送
        /// </summary>
        public bool AllowsShipping { get; set; }

        /// <summary>
        /// 两个字母的ISO代码
        /// </summary>
        public string TwoLetterIsoCode { get; set; }

        /// <summary>
        /// 三个字母的iso代码
        /// </summary>
        public string ThreeLetterIsoCode { get; set; }

        /// <summary>
        /// 数字编码
        /// </summary>
        public int NumericIsoCode { get; set; }

        /// <summary>
        /// 此国家/地区的客户是否必须收取欧盟增值税
        /// </summary>
        public bool SubjectToVat { get; set; }

        /// <summary>
        /// 该值指示实体是否已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 展示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 实体是否受限于某些商店
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// 地区或者省份
        /// </summary>
        public virtual ICollection<StateProvince> StateProvinces
        {
            get => _stateProvinces ?? (_stateProvinces = new List<StateProvince>());
            protected set => _stateProvinces = value;
        }

        /// <summary>
        /// 送货方法 - 国家/地区映射
        /// </summary>
        public virtual ICollection<ShippingMethodCountryMapping> ShippingMethodCountryMappings
        {
            get => _shippingMethodCountryMappings ?? (_shippingMethodCountryMappings = new List<ShippingMethodCountryMapping>());
            protected set => _shippingMethodCountryMappings = value;
        }
    }
}

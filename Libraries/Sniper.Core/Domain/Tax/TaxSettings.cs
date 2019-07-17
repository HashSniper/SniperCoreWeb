using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Tax
{
    public class TaxSettings : ISettings
    {
        /// <summary>
        /// TaxBasedOn
        /// </summary>
        public TaxBasedOn TaxBasedOn { get; set; }

        /// <summary>
        /// 是否使用取货点地址（选择取货点时）进行税务计算
        /// </summary>
        public bool TaxBasedOnPickupPointAddress { get; set; }

        /// <summary>
        /// 税显示类型
        /// </summary>
        public TaxDisplayType TaxDisplayType { get; set; }

        /// <summary>
        /// 活动税务提供者的系统名称
        /// </summary>
        public string ActiveTaxProviderSystemName { get; set; }

        /// <summary>
        /// 用于计税的默认地址
        /// </summary>
        public int DefaultTaxAddressId { get; set; }

        /// <summary>
        /// 是否显示税后缀
        /// </summary>
        public bool DisplayTaxSuffix { get; set; }

        /// <summary>
        /// 每个税率是否应显示在单独的行（购物车页面）
        /// </summary>
        public bool DisplayTaxRates { get; set; }

        /// <summary>
        /// 价格是否含税
        /// </summary>
        public bool PricesIncludeTax { get; set; }

        /// <summary>
        /// 是否允许客户选择税显示类型
        /// </summary>
        public bool AllowCustomersToSelectTaxDisplayType { get; set; }

        /// <summary>
        /// 是否隐藏零税
        /// </summary>
        public bool HideZeroTax { get; set; }

        /// <summary>
        /// 当价格显示为含税时，是否在订单摘要中隐藏税
        /// </summary>
        public bool HideTaxInOrderSummary { get; set; }

        /// <summary>
        /// 我们是否应该始终从订单小计中排除税收（无论选择的税收显示类型）
        /// </summary>
        public bool ForceTaxExclusionFromOrderSubtotal { get; set; }

        /// <summary>
        /// 产品的默认税类别标识符
        /// </summary>
        public int DefaultTaxCategoryId { get; set; }

        /// <summary>
        /// 表示运费是否应纳税的值
        /// </summary>
        public bool ShippingIsTaxable { get; set; }

        /// <summary>
        /// 表明运费价格是否含税
        /// </summary>
        public bool ShippingPriceIncludesTax { get; set; }

        /// <summary>
        /// 表示运输税类标识符的值
        /// </summary>
        public int ShippingTaxClassId { get; set; }

        /// <summary>
        /// 付款方式附加费是否应纳税
        /// </summary>
        public bool PaymentMethodAdditionalFeeIsTaxable { get; set; }

        /// <summary>
        /// 是否支付方式附加费包括税
        /// </summary>
        public bool PaymentMethodAdditionalFeeIncludesTax { get; set; }

        /// <summary>
        /// 付款方式附加费用税类标识符
        /// </summary>
        public int PaymentMethodAdditionalFeeTaxClassId { get; set; }

        /// <summary>
        /// 是否启用欧盟增值税（欧盟增值税）
        /// </summary>
        public bool EuVatEnabled { get; set; }

        /// <summary>
        /// 商店国家标识符
        /// </summary>
        public int EuVatShopCountryId { get; set; }

        /// <summary>
        /// 该商店是否将免除增值税的合格增值税登记客户
        /// </summary>
        public bool EuVatAllowVatExemption { get; set; }

        /// <summary>
        /// 我们是否应该使用欧盟网络服务来验证增值税号码
        /// </summary>
        public bool EuVatUseWebService { get; set; }

        /// <summary>
        /// whether VAT numbers should be automatically assumed valid
        /// </summary>
        public bool EuVatAssumeValid { get; set; }

        /// <summary>
        /// 我们是否应在提交新的增值税号时通知店主
        /// </summary>
        public bool EuVatEmailAdminWhenNewVatSubmitted { get; set; }

        /// <summary>
        /// 是否记录税务提供者的错误
        /// </summary>
        public bool LogErrors { get; set; }


    }
}

using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Directory;
using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Catalog
{
    public partial interface IPriceFormatter
    {
        /// <summary>
        /// 格式化价格
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        string FormatPrice(decimal price);

        /// <summary>
        /// 格式化价格
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <param name="targetCurrency"></param>
        /// <returns></returns>
        string FormatPrice(decimal price, bool showCurrency, Currency targetCurrency);

        /// <summary>
        /// 格式化价格
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <param name="showTax"></param>
        /// <returns></returns>
        string FormatPrice(decimal price, bool showCurrency, bool showTax);

        /// <summary>
        /// 格式化价格
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <param name="currencyCode"></param>
        /// <param name="showTax"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        string FormatPrice(decimal price, bool showCurrency,
            string currencyCode, bool showTax, Language language);

        /// <summary>
        /// 格式化价格
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <param name="currencyCode"></param>
        /// <param name="language"></param>
        /// <param name="priceIncludesTax"></param>
        /// <returns></returns>
        string FormatPrice(decimal price, bool showCurrency,
           string currencyCode, Language language, bool priceIncludesTax);

        /// <summary>
        /// 格式化价格
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <param name="targetCurrency"></param>
        /// <param name="language"></param>
        /// <param name="priceIncludesTax"></param>
        /// <returns></returns>
        string FormatPrice(decimal price, bool showCurrency,
          Currency targetCurrency, Language language, bool priceIncludesTax);

        /// <summary>
        /// 格式化价格
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <param name="targetCurrency"></param>
        /// <param name="language"></param>
        /// <param name="priceIncludesTax"></param>
        /// <param name="showTax"></param>
        /// <returns></returns>
        string FormatPrice(decimal price, bool showCurrency,
         Currency targetCurrency, Language language, bool priceIncludesTax, bool showTax);

        /// <summary>
        /// 格式化租赁产品的价格（租期）
        /// </summary>
        /// <param name="product"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        string FormatRentalProductPeriod(Product product, string price);

        /// <summary>
        /// 格式化运费
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <returns></returns>
        string FormatShippingPrice(decimal price, bool showCurrency);

        /// <summary>
        /// 格式化运费
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <param name="targetCurrency"></param>
        /// <param name="language"></param>
        /// <param name="priceIncludesTax"></param>
        /// <returns></returns>
        string FormatShippingPrice(decimal price, bool showCurrency,
            Currency targetCurrency, Language language, bool priceIncludesTax);

        /// <summary>
        /// 格式化运费
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <param name="targetCurrency"></param>
        /// <param name="language"></param>
        /// <param name="priceIncludesTax"></param>
        /// <param name="showTax"></param>
        /// <returns></returns>
        string FormatShippingPrice(decimal price, bool showCurrency,
           Currency targetCurrency, Language language, bool priceIncludesTax, bool showTax);

        /// <summary>
        /// 格式化运费
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <param name="currencyCode"></param>
        /// <param name="language"></param>
        /// <param name="priceIncludesTax"></param>
        /// <returns></returns>
        string FormatShippingPrice(decimal price, bool showCurrency,
          string currencyCode, Language language, bool priceIncludesTax);

        /// <summary>
        /// 格式化付款方式的额外费用
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <returns></returns>
        string FormatPaymentMethodAdditionalFee(decimal price, bool showCurrency);

        /// <summary>
        /// 格式化付款方式的额外费用
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <param name="targetCurrency"></param>
        /// <param name="language"></param>
        /// <param name="priceIncludesTax"></param>
        /// <returns></returns>
        string FormatPaymentMethodAdditionalFee(decimal price, bool showCurrency,
            Currency targetCurrency, Language language, bool priceIncludesTax);

        /// <summary>
        /// 格式化付款方式的额外费用
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <param name="targetCurrency"></param>
        /// <param name="language"></param>
        /// <param name="priceIncludesTax"></param>
        /// <param name="showTax"></param>
        /// <returns></returns>
        string FormatPaymentMethodAdditionalFee(decimal price, bool showCurrency,
          Currency targetCurrency, Language language, bool priceIncludesTax, bool showTax);

        /// <summary>
        /// 格式化付款方式的额外费用
        /// </summary>
        /// <param name="price"></param>
        /// <param name="showCurrency"></param>
        /// <param name="currencyCode"></param>
        /// <param name="language"></param>
        /// <param name="priceIncludesTax"></param>
        /// <returns></returns>
        string FormatPaymentMethodAdditionalFee(decimal price, bool showCurrency,
           string currencyCode, Language language, bool priceIncludesTax);

        /// <summary>
        /// 格式化税率
        /// </summary>
        /// <param name="taxRate"></param>
        /// <returns></returns>
        string FormatTaxRate(decimal taxRate);

        /// <summary>
        /// 格式化基础价格
        /// </summary>
        /// <param name="product"></param>
        /// <param name="productPrice"></param>
        /// <param name="totalWeight"></param>
        /// <returns></returns>
        string FormatBasePrice(Product product, decimal? productPrice, decimal? totalWeight = null);


    }
}

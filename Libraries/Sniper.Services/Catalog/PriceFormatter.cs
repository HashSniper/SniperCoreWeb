using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Directory;
using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Tax;
using Sniper.Services.Directory;
using Sniper.Services.Localization;

namespace Sniper.Services.Catalog
{
    public partial class PriceFormatter : IPriceFormatter
    {
        #region Fields

        private readonly CurrencySettings _currencySettings;
        private readonly ICurrencyService _currencyService;
        private readonly ILocalizationService _localizationService;
        private readonly IMeasureService _measureService;
        private readonly IWorkContext _workContext;
        private readonly TaxSettings _taxSettings;

        #endregion

        #region Ctor

        public PriceFormatter(CurrencySettings currencySettings,
            ICurrencyService currencyService,
            ILocalizationService localizationService,
            IMeasureService measureService,
            IWorkContext workContext,
            TaxSettings taxSettings)
        {
            _currencySettings = currencySettings;
            _currencyService = currencyService;
            _localizationService = localizationService;
            _measureService = measureService;
            _workContext = workContext;
            _taxSettings = taxSettings;
        }

        #endregion

        #region Methods
        public string FormatBasePrice(Product product, decimal? productPrice, decimal? totalWeight = null)
        {
            throw new NotImplementedException();
        }

        public string FormatPaymentMethodAdditionalFee(decimal price, bool showCurrency)
        {
            throw new NotImplementedException();
        }

        public string FormatPaymentMethodAdditionalFee(decimal price, bool showCurrency, Currency targetCurrency, Language language, bool priceIncludesTax)
        {
            throw new NotImplementedException();
        }

        public string FormatPaymentMethodAdditionalFee(decimal price, bool showCurrency, Currency targetCurrency, Language language, bool priceIncludesTax, bool showTax)
        {
            throw new NotImplementedException();
        }

        public string FormatPaymentMethodAdditionalFee(decimal price, bool showCurrency, string currencyCode, Language language, bool priceIncludesTax)
        {
            throw new NotImplementedException();
        }

        public string FormatPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public string FormatPrice(decimal price, bool showCurrency, Currency targetCurrency)
        {
            throw new NotImplementedException();
        }

        public string FormatPrice(decimal price, bool showCurrency, bool showTax)
        {
            throw new NotImplementedException();
        }

        public string FormatPrice(decimal price, bool showCurrency, string currencyCode, bool showTax, Language language)
        {
            throw new NotImplementedException();
        }

        public string FormatPrice(decimal price, bool showCurrency, string currencyCode, Language language, bool priceIncludesTax)
        {
            throw new NotImplementedException();
        }

        public string FormatPrice(decimal price, bool showCurrency, Currency targetCurrency, Language language, bool priceIncludesTax)
        {
            throw new NotImplementedException();
        }

        public string FormatPrice(decimal price, bool showCurrency, Currency targetCurrency, Language language, bool priceIncludesTax, bool showTax)
        {
            throw new NotImplementedException();
        }

        public string FormatRentalProductPeriod(Product product, string price)
        {
            throw new NotImplementedException();
        }

        public string FormatShippingPrice(decimal price, bool showCurrency)
        {
            throw new NotImplementedException();
        }

        public string FormatShippingPrice(decimal price, bool showCurrency, Currency targetCurrency, Language language, bool priceIncludesTax)
        {
            throw new NotImplementedException();
        }

        public string FormatShippingPrice(decimal price, bool showCurrency, Currency targetCurrency, Language language, bool priceIncludesTax, bool showTax)
        {
            throw new NotImplementedException();
        }

        public string FormatShippingPrice(decimal price, bool showCurrency, string currencyCode, Language language, bool priceIncludesTax)
        {
            throw new NotImplementedException();
        }

        public string FormatTaxRate(decimal taxRate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Common;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Orders;
using Sniper.Core.Domain.Shipping;
using Sniper.Core.Domain.Tax;
using Sniper.Services.Common;
using Sniper.Services.Directory;
using Sniper.Services.Logging;

namespace Sniper.Services.Tax
{
    public partial class TaxService : ITaxService
    {
        #region Fields

        private readonly AddressSettings _addressSettings;
        private readonly CustomerSettings _customerSettings;
        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IGeoLookupService _geoLookupService;
        private readonly ILogger _logger;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreContext _storeContext;
        private readonly ITaxPluginManager _taxPluginManager;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly ShippingSettings _shippingSettings;
        private readonly TaxSettings _taxSettings;

        #endregion

        #region Ctor

        public TaxService(AddressSettings addressSettings,
            CustomerSettings customerSettings,
            IAddressService addressService,
            ICountryService countryService,
            IGenericAttributeService genericAttributeService,
            IGeoLookupService geoLookupService,
            ILogger logger,
            IStateProvinceService stateProvinceService,
            IStaticCacheManager cacheManager,
            IStoreContext storeContext,
            ITaxPluginManager taxPluginManager,
            IWebHelper webHelper,
            IWorkContext workContext,
            ShippingSettings shippingSettings,
            TaxSettings taxSettings)
        {
            _addressSettings = addressSettings;
            _customerSettings = customerSettings;
            _addressService = addressService;
            _countryService = countryService;
            _genericAttributeService = genericAttributeService;
            _geoLookupService = geoLookupService;
            _logger = logger;
            _stateProvinceService = stateProvinceService;
            _cacheManager = cacheManager;
            _storeContext = storeContext;
            _taxPluginManager = taxPluginManager;
            _webHelper = webHelper;
            _workContext = workContext;
            _shippingSettings = shippingSettings;
            _taxSettings = taxSettings;
        }

        #endregion


        #region Methods
        public VatNumberStatus DoVatCheck(string twoLetterIsoCode, string vatNumber, out string name, out string address, out Exception exception)
        {
            throw new NotImplementedException();
        }

        public decimal GetCheckoutAttributePrice(CheckoutAttributeValue cav)
        {
            throw new NotImplementedException();
        }

        public decimal GetCheckoutAttributePrice(CheckoutAttributeValue cav, Customer customer)
        {
            throw new NotImplementedException();
        }

        public decimal GetCheckoutAttributePrice(CheckoutAttributeValue cav, bool includingTax, Customer customer)
        {
            throw new NotImplementedException();
        }

        public decimal GetCheckoutAttributePrice(CheckoutAttributeValue cav, bool includingTax, Customer customer, out decimal taxRate)
        {
            throw new NotImplementedException();
        }

        public decimal GetPaymentMethodAdditionalFee(decimal price, Customer customer)
        {
            throw new NotImplementedException();
        }

        public decimal GetPaymentMethodAdditionalFee(decimal price, bool includingTax, Customer customer)
        {
            throw new NotImplementedException();
        }

        public decimal GetPaymentMethodAdditionalFee(decimal price, bool includingTax, Customer customer, out decimal taxRate)
        {
            throw new NotImplementedException();
        }

        public decimal GetProductPrice(Product product, decimal price, out decimal taxRate)
        {
            throw new NotImplementedException();
        }

        public decimal GetProductPrice(Product product, decimal price, Customer customer, out decimal taxRate)
        {
            throw new NotImplementedException();
        }

        public decimal GetProductPrice(Product product, decimal price, bool includingTax, Customer customer, out decimal taxRate)
        {
            throw new NotImplementedException();
        }

        public decimal GetProductPrice(Product product, int taxCategoryId, decimal price, bool includingTax, Customer customer, bool priceIncludesTax, out decimal taxRate)
        {
            throw new NotImplementedException();
        }

        public decimal GetShippingPrice(decimal price, Customer customer)
        {
            throw new NotImplementedException();
        }

        public decimal GetShippingPrice(decimal price, bool includingTax, Customer customer)
        {
            throw new NotImplementedException();
        }

        public decimal GetShippingPrice(decimal price, bool includingTax, Customer customer, out decimal taxRate)
        {
            throw new NotImplementedException();
        }

        public VatNumberStatus GetVatNumberStatus(string fullVatNumber)
        {
            throw new NotImplementedException();
        }

        public VatNumberStatus GetVatNumberStatus(string fullVatNumber, out string name, out string address)
        {
            throw new NotImplementedException();
        }

        public VatNumberStatus GetVatNumberStatus(string twoLetterIsoCode, string vatNumber)
        {
            throw new NotImplementedException();
        }

        public VatNumberStatus GetVatNumberStatus(string twoLetterIsoCode, string vatNumber, out string name, out string address)
        {
            throw new NotImplementedException();
        }

        public bool IsTaxExempt(Product product, Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool IsVatExempt(CalculateTaxRequest.TaxAddress address, Customer customer)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

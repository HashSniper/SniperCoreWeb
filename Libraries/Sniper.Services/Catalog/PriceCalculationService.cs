using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Directory;
using Sniper.Core.Domain.Orders;
using Sniper.Services.Directory;
using Sniper.Services.Discounts;

namespace Sniper.Services.Catalog
{
    public partial class PriceCalculationService : IPriceCalculationService
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly CurrencySettings _currencySettings;
        private readonly ICategoryService _categoryService;
        private readonly ICurrencyService _currencyService;
        private readonly IDiscountService _discountService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IProductAttributeParser _productAttributeParser;
        private readonly IProductService _productService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;
        private readonly ShoppingCartSettings _shoppingCartSettings;

        #endregion

        #region Ctor

        public PriceCalculationService(CatalogSettings catalogSettings,
            CurrencySettings currencySettings,
            ICategoryService categoryService,
            ICurrencyService currencyService,
            IDiscountService discountService,
            IManufacturerService manufacturerService,
            IProductAttributeParser productAttributeParser,
            IProductService productService,
            IStaticCacheManager cacheManager,
            IStoreContext storeContext,
            IWorkContext workContext,
            ShoppingCartSettings shoppingCartSettings)
        {
            _catalogSettings = catalogSettings;
            _currencySettings = currencySettings;
            _categoryService = categoryService;
            _currencyService = currencyService;
            _discountService = discountService;
            _manufacturerService = manufacturerService;
            _productAttributeParser = productAttributeParser;
            _productService = productService;
            _cacheManager = cacheManager;
            _storeContext = storeContext;
            _workContext = workContext;
            _shoppingCartSettings = shoppingCartSettings;
        }

        #endregion

        #region Methods
        public decimal GetFinalPrice(Product product, Customer customer, decimal additionalCharge = 0, bool includeDiscounts = true, int quantity = 1)
        {
            throw new NotImplementedException();
        }

        public decimal GetFinalPrice(Product product, Customer customer, decimal additionalCharge, bool includeDiscounts, int quantity, out decimal discountAmount, out List<DiscountForCaching> appliedDiscounts)
        {
            throw new NotImplementedException();
        }

        public decimal GetFinalPrice(Product product, Customer customer, decimal additionalCharge, bool includeDiscounts, int quantity, DateTime? rentalStartDate, DateTime? rentalEndDate, out decimal discountAmount, out List<DiscountForCaching> appliedDiscounts)
        {
            throw new NotImplementedException();
        }

        public decimal GetProductAttributeValuePriceAdjustment(ProductAttributeValue value, Customer customer, decimal? productPrice = null)
        {
            throw new NotImplementedException();
        }

        public decimal GetProductCost(Product product, string attributesXml)
        {
            throw new NotImplementedException();
        }

        public decimal GetSubTotal(ShoppingCartItem shoppingCartItem, bool includeDiscounts = true)
        {
            throw new NotImplementedException();
        }

        public decimal GetSubTotal(ShoppingCartItem shoppingCartItem, bool includeDiscounts, out decimal discountAmount, out List<DiscountForCaching> appliedDiscounts, out int? maximumDiscountQty)
        {
            throw new NotImplementedException();
        }

        public decimal GetUnitPrice(ShoppingCartItem shoppingCartItem, bool includeDiscounts = true)
        {
            throw new NotImplementedException();
        }

        public decimal GetUnitPrice(ShoppingCartItem shoppingCartItem, bool includeDiscounts, out decimal discountAmount, out List<DiscountForCaching> appliedDiscounts)
        {
            throw new NotImplementedException();
        }

        public decimal GetUnitPrice(Product product, Customer customer, ShoppingCartType shoppingCartType, int quantity, string attributesXml, decimal customerEnteredPrice, DateTime? rentalStartDate, DateTime? rentalEndDate, bool includeDiscounts, out decimal discountAmount, out List<DiscountForCaching> appliedDiscounts)
        {
            throw new NotImplementedException();
        }

        public decimal Round(decimal value, RoundingType roundingType)
        {
            throw new NotImplementedException();
        }

        public decimal RoundPrice(decimal value, Currency currency = null)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

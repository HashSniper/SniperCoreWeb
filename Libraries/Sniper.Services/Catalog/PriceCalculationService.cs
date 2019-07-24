using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Directory;
using Sniper.Core.Domain.Discounts;
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
        /// <summary>
        /// 获取最终价格
        /// </summary>
        /// <param name="product"></param>
        /// <param name="customer"></param>
        /// <param name="additionalCharge"></param>
        /// <param name="includeDiscounts"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public virtual decimal GetFinalPrice(Product product, Customer customer, decimal additionalCharge = 0, bool includeDiscounts = true, int quantity = 1)
        {
            return GetFinalPrice(product, customer, additionalCharge, includeDiscounts,
               quantity, out _, out _);
        }

        public virtual decimal GetFinalPrice(Product product, Customer customer, decimal additionalCharge, bool includeDiscounts, int quantity, out decimal discountAmount, out List<DiscountForCaching> appliedDiscounts)
        {
            return GetFinalPrice(product, customer,
                additionalCharge, includeDiscounts, quantity,
                null, null,
                out discountAmount, out appliedDiscounts);
        }

        public virtual decimal GetFinalPrice(Product product, Customer customer, decimal additionalCharge, bool includeDiscounts, int quantity, DateTime? rentalStartDate, DateTime? rentalEndDate, out decimal discountAmount, out List<DiscountForCaching> appliedDiscounts)
        {
            return GetFinalPrice(product, customer, null, additionalCharge, includeDiscounts, quantity,
               rentalStartDate, rentalEndDate, out discountAmount, out appliedDiscounts);
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

        #region Utilities
        public virtual decimal GetFinalPrice(Product product,
            Customer customer,
            decimal? overriddenProductPrice,
            decimal additionalCharge,
            bool includeDiscounts,
            int quantity,
            DateTime? rentalStartDate,
            DateTime? rentalEndDate,
            out decimal discountAmount,
            out List<DiscountForCaching> appliedDiscounts)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            discountAmount = decimal.Zero;
            appliedDiscounts = new List<DiscountForCaching>();

            var cacheKey = string.Format(NopCatalogDefaults.ProductPriceModelCacheKey,
                product.Id,
                overriddenProductPrice?.ToString(CultureInfo.InvariantCulture),
                additionalCharge.ToString(CultureInfo.InvariantCulture),
                includeDiscounts,
                quantity,
                string.Join(",", customer.GetCustomerRoleIds()),
                _storeContext.CurrentStore.Id);
            var cacheTime = _catalogSettings.CacheProductPrices ? 60 : 0;
            //we do not cache price for rental products
            //otherwise, it can cause memory leaks (to store all possible date period combinations)
            if (product.IsRental)
                cacheTime = 0;
            var cachedPrice = _cacheManager.Get(cacheKey, () =>
            {
                var result = new ProductPriceForCaching();

                //initial price
                var price = overriddenProductPrice ?? product.Price;

                //tier prices
                var tierPrice = _productService.GetPreferredTierPrice(product, customer, _storeContext.CurrentStore.Id, quantity);
                if (tierPrice != null)
                    price = tierPrice.Price;

                //additional charge
                price = price + additionalCharge;

                //rental products
                if (product.IsRental)
                    if (rentalStartDate.HasValue && rentalEndDate.HasValue)
                        price = price * _productService.GetRentalPeriods(product, rentalStartDate.Value, rentalEndDate.Value);

                if (includeDiscounts)
                {
                    //discount
                    var tmpDiscountAmount = GetDiscountAmount(product, customer, price, out var tmpAppliedDiscounts);
                    price = price - tmpDiscountAmount;

                    if (tmpAppliedDiscounts?.Any() ?? false)
                    {
                        result.AppliedDiscounts = tmpAppliedDiscounts;
                        result.AppliedDiscountAmount = tmpDiscountAmount;
                    }
                }

                if (price < decimal.Zero)
                    price = decimal.Zero;

                result.Price = price;
                return result;
            }, cacheTime);

            if (!includeDiscounts)
                return cachedPrice.Price;

            if (!cachedPrice.AppliedDiscounts.Any())
                return cachedPrice.Price;

            appliedDiscounts.AddRange(cachedPrice.AppliedDiscounts);
            discountAmount = cachedPrice.AppliedDiscountAmount;

            return cachedPrice.Price;
        }


        /// <summary>
        /// 获得折扣金额
        /// </summary>
        /// <param name="product"></param>
        /// <param name="customer"></param>
        /// <param name="productPriceWithoutDiscount"></param>
        /// <param name="appliedDiscounts"></param>
        /// <returns></returns>
        protected virtual decimal GetDiscountAmount(Product product,
            Customer customer,
            decimal productPriceWithoutDiscount,
            out List<DiscountForCaching> appliedDiscounts)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            appliedDiscounts = new List<DiscountForCaching>();
            var appliedDiscountAmount = decimal.Zero;

            //we don't apply discounts to products with price entered by a customer
            if (product.CustomerEntersPrice)
                return appliedDiscountAmount;

            //discounts are disabled
            if (_catalogSettings.IgnoreDiscounts)
                return appliedDiscountAmount;

            var allowedDiscounts = GetAllowedDiscounts(product, customer);

            //no discounts
            if (!allowedDiscounts.Any())
                return appliedDiscountAmount;

            appliedDiscounts = _discountService.GetPreferredDiscount(allowedDiscounts, productPriceWithoutDiscount, out appliedDiscountAmount);
            return appliedDiscountAmount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        protected virtual IList<DiscountForCaching> GetAllowedDiscounts(Product product, Customer customer)
        {
            var allowedDiscounts = new List<DiscountForCaching>();
            if (_catalogSettings.IgnoreDiscounts)
                return allowedDiscounts;

            //discounts applied to products
            foreach (var discount in GetAllowedDiscountsAppliedToProduct(product, customer))
                if (!_discountService.ContainsDiscount(allowedDiscounts, discount))
                    allowedDiscounts.Add(discount);

            //discounts applied to categories
            foreach (var discount in GetAllowedDiscountsAppliedToCategories(product, customer))
                if (!_discountService.ContainsDiscount(allowedDiscounts, discount))
                    allowedDiscounts.Add(discount);

            //discounts applied to manufacturers
            foreach (var discount in GetAllowedDiscountsAppliedToManufacturers(product, customer))
                if (!_discountService.ContainsDiscount(allowedDiscounts, discount))
                    allowedDiscounts.Add(discount);

            return allowedDiscounts;
        }

        protected virtual IList<DiscountForCaching> GetAllowedDiscountsAppliedToProduct(Product product, Customer customer)
        {
            var allowedDiscounts = new List<DiscountForCaching>();
            if (_catalogSettings.IgnoreDiscounts)
                return allowedDiscounts;

            if (!product.HasDiscountsApplied)
                return allowedDiscounts;

            //we use this property ("HasDiscountsApplied") for performance optimization to avoid unnecessary database calls
            foreach (var discount in product.AppliedDiscounts)
            {
                if (discount.DiscountType == DiscountType.AssignedToSkus &&
                    _discountService.ValidateDiscount(discount, customer).IsValid)
                    allowedDiscounts.Add(_discountService.MapDiscount(discount));
            }

            return allowedDiscounts;
        }

        protected virtual IList<DiscountForCaching> GetAllowedDiscountsAppliedToCategories(Product product, Customer customer)
        {
            var allowedDiscounts = new List<DiscountForCaching>();
            if (_catalogSettings.IgnoreDiscounts)
                return allowedDiscounts;

            //load cached discount models (performance optimization)
            foreach (var discount in _discountService.GetAllDiscountsForCaching(DiscountType.AssignedToCategories))
            {
                //load identifier of categories with this discount applied to
                var discountCategoryIds = _discountService.GetAppliedCategoryIds(discount, customer);

                //compare with categories of this product
                var productCategoryIds = new List<int>();
                if (discountCategoryIds.Any())
                {
                    //load identifier of categories of this product
                    var cacheKey = string.Format(NopCatalogDefaults.ProductCategoryIdsModelCacheKey,
                        product.Id,
                        string.Join(",", customer.GetCustomerRoleIds()),
                        _storeContext.CurrentStore.Id);
                    productCategoryIds = _cacheManager.Get(cacheKey, () =>
                        _categoryService
                        .GetProductCategoriesByProductId(product.Id)
                        .Select(x => x.CategoryId)
                        .ToList());
                }

                foreach (var categoryId in productCategoryIds)
                {
                    if (!discountCategoryIds.Contains(categoryId))
                        continue;

                    if (!_discountService.ContainsDiscount(allowedDiscounts, discount) &&
                        _discountService.ValidateDiscount(discount, customer).IsValid)
                        allowedDiscounts.Add(discount);
                }
            }

            return allowedDiscounts;
        }

        protected virtual IList<DiscountForCaching> GetAllowedDiscountsAppliedToManufacturers(Product product, Customer customer)
        {
            var allowedDiscounts = new List<DiscountForCaching>();
            if (_catalogSettings.IgnoreDiscounts)
                return allowedDiscounts;

            foreach (var discount in _discountService.GetAllDiscountsForCaching(DiscountType.AssignedToManufacturers))
            {
                //load identifier of manufacturers with this discount applied to
                var discountManufacturerIds = _discountService.GetAppliedManufacturerIds(discount, customer);

                //compare with manufacturers of this product
                var productManufacturerIds = new List<int>();
                if (discountManufacturerIds.Any())
                {
                    //load identifier of manufacturers of this product
                    var cacheKey = string.Format(NopCatalogDefaults.ProductManufacturerIdsModelCacheKey,
                        product.Id,
                        string.Join(",", customer.GetCustomerRoleIds()),
                        _storeContext.CurrentStore.Id);
                    productManufacturerIds = _cacheManager.Get(cacheKey, () =>
                        _manufacturerService
                        .GetProductManufacturersByProductId(product.Id)
                        .Select(x => x.ManufacturerId)
                        .ToList());
                }

                foreach (var manufacturerId in productManufacturerIds)
                {
                    if (!discountManufacturerIds.Contains(manufacturerId))
                        continue;

                    if (!_discountService.ContainsDiscount(allowedDiscounts, discount) &&
                        _discountService.ValidateDiscount(discount, customer).IsValid)
                        allowedDiscounts.Add(discount);
                }
            }

            return allowedDiscounts;
        }

        #endregion

        #region Nested classes

        /// <summary>
        /// Product price (for caching)
        /// </summary>
        [Serializable]
        protected class ProductPriceForCaching
        {
            public ProductPriceForCaching()
            {
                AppliedDiscounts = new List<DiscountForCaching>();
            }

            /// <summary>
            /// Price
            /// </summary>
            public decimal Price { get; set; }

            /// <summary>
            /// Applied discount amount
            /// </summary>
            public decimal AppliedDiscountAmount { get; set; }

            /// <summary>
            /// Applied discounts
            /// </summary>
            public List<DiscountForCaching> AppliedDiscounts { get; set; }
        }

        #endregion
    }
}

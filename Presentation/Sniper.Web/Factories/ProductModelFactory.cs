using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Media;
using Sniper.Core.Domain.Orders;
using Sniper.Core.Domain.Security;
using Sniper.Core.Domain.Seo;
using Sniper.Core.Domain.Vendors;
using Sniper.Services.Catalog;
using Sniper.Services.Customers;
using Sniper.Services.Directory;
using Sniper.Services.Helpers;
using Sniper.Services.Localization;
using Sniper.Services.Media;
using Sniper.Services.Security;
using Sniper.Services.Seo;
using Sniper.Services.Shipping.Date;
using Sniper.Services.Tax;
using Sniper.Services.Vendors;
using Sniper.Web.Infrastructure.Cache;
using Sniper.Web.Models.Catalog;
using Sniper.Web.Models.Media;


namespace Sniper.Web.Factories
{
    public partial class ProductModelFactory : IProductModelFactory
    {
        #region Fields

        private readonly CaptchaSettings _captchaSettings;
        private readonly CatalogSettings _catalogSettings;
        private readonly CustomerSettings _customerSettings;
        private readonly ICategoryService _categoryService;
        private readonly ICurrencyService _currencyService;
        private readonly ICustomerService _customerService;
        private readonly IDateRangeService _dateRangeService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IDownloadService _downloadService;
        private readonly ILocalizationService _localizationService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IPermissionService _permissionService;
        private readonly IPictureService _pictureService;
        private readonly IPriceCalculationService _priceCalculationService;
        private readonly IPriceFormatter _priceFormatter;
        private readonly IProductAttributeParser _productAttributeParser;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IProductService _productService;
        private readonly IProductTagService _productTagService;
        private readonly IProductTemplateService _productTemplateService;
        private readonly IReviewTypeService _reviewTypeService;
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreContext _storeContext;
        private readonly ITaxService _taxService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IVendorService _vendorService;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly MediaSettings _mediaSettings;
        private readonly OrderSettings _orderSettings;
        private readonly SeoSettings _seoSettings;
        private readonly VendorSettings _vendorSettings;

        #endregion

        #region Ctor

        public ProductModelFactory(CaptchaSettings captchaSettings,
            CatalogSettings catalogSettings,
            CustomerSettings customerSettings,
            ICategoryService categoryService,
            ICurrencyService currencyService,
            ICustomerService customerService,
            IDateRangeService dateRangeService,
            IDateTimeHelper dateTimeHelper,
            IDownloadService downloadService,
            ILocalizationService localizationService,
            IManufacturerService manufacturerService,
            IPermissionService permissionService,
            IPictureService pictureService,
            IPriceCalculationService priceCalculationService,
            IPriceFormatter priceFormatter,
            IProductAttributeParser productAttributeParser,
            IProductAttributeService productAttributeService,
            IProductService productService,
            IProductTagService productTagService,
            IProductTemplateService productTemplateService,
            IReviewTypeService reviewTypeService,
            ISpecificationAttributeService specificationAttributeService,
            IStaticCacheManager cacheManager,
            IStoreContext storeContext,
            ITaxService taxService,
            IUrlRecordService urlRecordService,
            IVendorService vendorService,
            IWebHelper webHelper,
            IWorkContext workContext,
            MediaSettings mediaSettings,
            OrderSettings orderSettings,
            SeoSettings seoSettings,
            VendorSettings vendorSettings)
        {
            _captchaSettings = captchaSettings;
            _catalogSettings = catalogSettings;
            _customerSettings = customerSettings;
            _categoryService = categoryService;
            _currencyService = currencyService;
            _customerService = customerService;
            _dateRangeService = dateRangeService;
            _dateTimeHelper = dateTimeHelper;
            _downloadService = downloadService;
            _localizationService = localizationService;
            _manufacturerService = manufacturerService;
            _permissionService = permissionService;
            _pictureService = pictureService;
            _priceCalculationService = priceCalculationService;
            _priceFormatter = priceFormatter;
            _productAttributeParser = productAttributeParser;
            _productAttributeService = productAttributeService;
            _productService = productService;
            _productTagService = productTagService;
            _productTemplateService = productTemplateService;
            _reviewTypeService = reviewTypeService;
            _specificationAttributeService = specificationAttributeService;
            _cacheManager = cacheManager;
            _storeContext = storeContext;
            _taxService = taxService;
            _urlRecordService = urlRecordService;
            _vendorService = vendorService;
            _webHelper = webHelper;
            _workContext = workContext;
            _mediaSettings = mediaSettings;
            _orderSettings = orderSettings;
            _seoSettings = seoSettings;
            _vendorSettings = vendorSettings;
        }

        #endregion

        #region Methods
        public CustomerProductReviewsModel PrepareCustomerProductReviewsModel(int? page)
        {
            throw new NotImplementedException();
        }

        public ProductDetailsModel PrepareProductDetailsModel(Product product, ShoppingCartItem updatecartitem = null, bool isAssociatedProduct = false)
        {
            throw new NotImplementedException();
        }

        public ProductEmailAFriendModel PrepareProductEmailAFriendModel(ProductEmailAFriendModel model, Product product, bool excludeProperties)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 准备产品概述模型
        /// </summary>
        /// <param name="products"></param>
        /// <param name="preparePriceModel"></param>
        /// <param name="preparePictureModel"></param>
        /// <param name="productThumbPictureSize"></param>
        /// <param name="prepareSpecificationAttributes"></param>
        /// <param name="forceRedirectionAfterAddingToCart"></param>
        /// <returns></returns>
        public virtual IEnumerable<ProductOverviewModel> PrepareProductOverviewModels(IEnumerable<Product> products, bool preparePriceModel = true, bool preparePictureModel = true, int? productThumbPictureSize = null, bool prepareSpecificationAttributes = false, bool forceRedirectionAfterAddingToCart = false)
        {
            if (products == null)
                throw new ArgumentNullException(nameof(products));

            var models = new List<ProductOverviewModel>();

            foreach (var product in products)
            {
                var model = new ProductOverviewModel
                {
                    Id = product.Id,
                    Name = _localizationService.GetLocalized(product, x => x.Name),
                    ShortDescription = _localizationService.GetLocalized(product, x => x.ShortDescription),
                    FullDescription = _localizationService.GetLocalized(product, x => x.FullDescription),
                    SeName = _urlRecordService.GetSeName(product),
                    Sku = product.Sku,
                    ProductType = product.ProductType,
                    MarkAsNew = product.MarkAsNew &&
                        (!product.MarkAsNewStartDateTimeUtc.HasValue || product.MarkAsNewStartDateTimeUtc.Value < DateTime.UtcNow) &&
                        (!product.MarkAsNewEndDateTimeUtc.HasValue || product.MarkAsNewEndDateTimeUtc.Value > DateTime.UtcNow)
                };

                if (preparePriceModel)
                {
                    model.ProductPrice = PrepareProductOverviewPriceModel(product, forceRedirectionAfterAddingToCart);
                }

                if (preparePictureModel)
                {
                    model.DefaultPictureModel = PrepareProductOverviewPictureModel(product, productThumbPictureSize);
                }

                if (prepareSpecificationAttributes)
                {
                    model.SpecificationAttributeModels = PrepareProductSpecificationModel(product);
                }

                model.ReviewOverviewModel = PrepareProductReviewOverviewModel(product);

                models.Add(model);
            }

            return models;
        }

        public ProductReviewsModel PrepareProductReviewsModel(ProductReviewsModel model, Product product)
        {
            throw new NotImplementedException();
        }

        public IList<ProductSpecificationModel> PrepareProductSpecificationModel(Product product)
        {
            throw new NotImplementedException();
        }

        public string PrepareProductTemplateViewPath(Product product)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Utilities
        protected virtual ProductOverviewModel.ProductPriceModel PrepareProductOverviewPriceModel(Product product, bool forceRedirectionAfterAddingToCart = false)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var priceModel = new ProductOverviewModel.ProductPriceModel
            {
                ForceRedirectionAfterAddingToCart = forceRedirectionAfterAddingToCart
            };

            switch (product.ProductType)
            {
                case ProductType.GroupedProduct:
                    {
                        //grouped product
                        PrepareGroupedProductOverviewPriceModel(product, priceModel);
                    }
                    break;
                case ProductType.SimpleProduct:
                default:
                    {
                        //simple product
                        PrepareSimpleProductOverviewPriceModel(product, priceModel);
                    }
                    break;
            }

            return priceModel;
        }

        protected virtual void PrepareSimpleProductOverviewPriceModel(Product product, ProductOverviewModel.ProductPriceModel priceModel)
        {
            //add to cart button
            priceModel.DisableBuyButton = product.DisableBuyButton ||
                                          !_permissionService.Authorize(StandardPermissionProvider.EnableShoppingCart) ||
                                          !_permissionService.Authorize(StandardPermissionProvider.DisplayPrices);

            //add to wishlist button
            priceModel.DisableWishlistButton = product.DisableWishlistButton ||
                                               !_permissionService.Authorize(StandardPermissionProvider.EnableWishlist) ||
                                               !_permissionService.Authorize(StandardPermissionProvider.DisplayPrices);
            //compare products
            priceModel.DisableAddToCompareListButton = !_catalogSettings.CompareProductsEnabled;

            //rental
            priceModel.IsRental = product.IsRental;

            //pre-order
            if (product.AvailableForPreOrder)
            {
                priceModel.AvailableForPreOrder = !product.PreOrderAvailabilityStartDateTimeUtc.HasValue ||
                                                  product.PreOrderAvailabilityStartDateTimeUtc.Value >=
                                                  DateTime.UtcNow;
                priceModel.PreOrderAvailabilityStartDateTimeUtc = product.PreOrderAvailabilityStartDateTimeUtc;
            }

            //prices
            if (_permissionService.Authorize(StandardPermissionProvider.DisplayPrices))
            {
                if (product.CustomerEntersPrice)
                    return;

                if (product.CallForPrice &&
                    //also check whether the current user is impersonated
                    (!_orderSettings.AllowAdminsToBuyCallForPriceProducts ||
                     _workContext.OriginalCustomerIfImpersonated == null))
                {
                    //call for price
                    priceModel.OldPrice = null;
                    priceModel.Price = _localizationService.GetResource("Products.CallForPrice");
                }
                else
                {
                    //prices
                    var minPossiblePriceWithoutDiscount = _priceCalculationService.GetFinalPrice(product, _workContext.CurrentCustomer, includeDiscounts: false);
                    var minPossiblePriceWithDiscount = _priceCalculationService.GetFinalPrice(product, _workContext.CurrentCustomer, includeDiscounts: true);

                    if (product.HasTierPrices)
                    {
                        //calculate price for the maximum quantity if we have tier prices, and choose minimal
                        minPossiblePriceWithoutDiscount = Math.Min(minPossiblePriceWithoutDiscount,
                            _priceCalculationService.GetFinalPrice(product, _workContext.CurrentCustomer, includeDiscounts: false, quantity: int.MaxValue));
                        minPossiblePriceWithDiscount = Math.Min(minPossiblePriceWithDiscount,
                            _priceCalculationService.GetFinalPrice(product, _workContext.CurrentCustomer, includeDiscounts: true, quantity: int.MaxValue));
                    }

                    var oldPriceBase = _taxService.GetProductPrice(product, product.OldPrice, out decimal _);
                    var finalPriceWithoutDiscountBase = _taxService.GetProductPrice(product, minPossiblePriceWithoutDiscount, out _);
                    var finalPriceWithDiscountBase = _taxService.GetProductPrice(product, minPossiblePriceWithDiscount, out _);

                    var oldPrice = _currencyService.ConvertFromPrimaryStoreCurrency(oldPriceBase, _workContext.WorkingCurrency);
                    var finalPriceWithoutDiscount = _currencyService.ConvertFromPrimaryStoreCurrency(finalPriceWithoutDiscountBase, _workContext.WorkingCurrency);
                    var finalPriceWithDiscount = _currencyService.ConvertFromPrimaryStoreCurrency(finalPriceWithDiscountBase, _workContext.WorkingCurrency);

                    //do we have tier prices configured?
                    var tierPrices = new List<TierPrice>();
                    if (product.HasTierPrices)
                    {
                        tierPrices.AddRange(product.TierPrices.OrderBy(tp => tp.Quantity)
                            .FilterByStore(_storeContext.CurrentStore.Id)
                            .FilterForCustomer(_workContext.CurrentCustomer)
                            .FilterByDate()
                            .RemoveDuplicatedQuantities());
                    }
                    //When there is just one tier price (with  qty 1), there are no actual savings in the list.
                    var displayFromMessage = tierPrices.Any() && !(tierPrices.Count == 1 && tierPrices[0].Quantity <= 1);
                    if (displayFromMessage)
                    {
                        priceModel.OldPrice = null;
                        priceModel.Price = string.Format(_localizationService.GetResource("Products.PriceRangeFrom"), _priceFormatter.FormatPrice(finalPriceWithDiscount));
                        priceModel.PriceValue = finalPriceWithDiscount;
                    }
                    else
                    {
                        var strikeThroughPrice = decimal.Zero;

                        if (finalPriceWithoutDiscountBase != oldPriceBase && oldPriceBase > decimal.Zero)
                            strikeThroughPrice = oldPrice;

                        if (finalPriceWithoutDiscountBase != finalPriceWithDiscountBase)
                            strikeThroughPrice = finalPriceWithoutDiscount;

                        if (strikeThroughPrice > decimal.Zero)
                            priceModel.OldPrice = _priceFormatter.FormatPrice(strikeThroughPrice);

                        priceModel.Price = _priceFormatter.FormatPrice(finalPriceWithDiscount);
                        priceModel.PriceValue = finalPriceWithDiscount;
                    }

                    if (product.IsRental)
                    {
                        //rental product
                        priceModel.OldPrice = _priceFormatter.FormatRentalProductPeriod(product, priceModel.OldPrice);
                        priceModel.Price = _priceFormatter.FormatRentalProductPeriod(product, priceModel.Price);
                    }

                    //property for German market
                    //we display tax/shipping info only with "shipping enabled" for this product
                    //we also ensure this it's not free shipping
                    priceModel.DisplayTaxShippingInfo = _catalogSettings.DisplayTaxShippingInfoProductBoxes && product.IsShipEnabled && !product.IsFreeShipping;

                    //PAngV default baseprice (used in Germany)
                    priceModel.BasePricePAngV = _priceFormatter.FormatBasePrice(product, finalPriceWithDiscount);
                }
            }
            else
            {
                //hide prices
                priceModel.OldPrice = null;
                priceModel.Price = null;
            }
        }


        protected virtual void PrepareGroupedProductOverviewPriceModel(Product product, ProductOverviewModel.ProductPriceModel priceModel)
        {
            var associatedProducts = _productService.GetAssociatedProducts(product.Id, _storeContext.CurrentStore.Id);

            priceModel.DisableBuyButton = !_permissionService.Authorize(StandardPermissionProvider.EnableShoppingCart) ||
                !_permissionService.Authorize(StandardPermissionProvider.DisplayPrices);

            priceModel.DisableWishlistButton =
              !_permissionService.Authorize(StandardPermissionProvider.EnableWishlist) ||
              !_permissionService.Authorize(StandardPermissionProvider.DisplayPrices);

            priceModel.DisableAddToCompareListButton = !_catalogSettings.CompareProductsEnabled;

            if (!associatedProducts.Any())
            {
                return;
            }

            if (_permissionService.Authorize(StandardPermissionProvider.DisplayPrices))
            {
                decimal? minPossiblePrice = null;
                Product minPriceProduct = null;

                foreach (var associatedProduct in associatedProducts)
                {
                    var tmpMinPossiblePrice = _priceCalculationService.GetFinalPrice(associatedProduct, _workContext.CurrentCustomer);

                    if (associatedProduct.HasTierPrices)
                    {
                        tmpMinPossiblePrice = Math.Min(tmpMinPossiblePrice, _priceCalculationService.GetFinalPrice(associatedProduct, _workContext.CurrentCustomer, quantity: int.MaxValue));

                    }

                    if (minPossiblePrice.HasValue && tmpMinPossiblePrice >= minPossiblePrice.Value)
                    {
                        continue;
                    }

                    minPriceProduct = associatedProduct;
                    minPossiblePrice = tmpMinPossiblePrice;
                }

                if (minPriceProduct == null || minPriceProduct.CustomerEntersPrice)
                {
                    return;
                }

                if (minPriceProduct.CallForPrice &&
                               (!_orderSettings.AllowAdminsToBuyCallForPriceProducts ||
                     _workContext.OriginalCustomerIfImpersonated == null))
                {
                    priceModel.OldPrice = null;

                    priceModel.Price = _localizationService.GetResource("Products.CallForPrice");
                }
                else
                {
                    var finalPriceBase = _taxService.GetProductPrice(minPriceProduct, minPossiblePrice.Value, out decimal _);
                    var finalPrice = _currencyService.ConvertFromPrimaryStoreCurrency(finalPriceBase, _workContext.WorkingCurrency);

                    priceModel.OldPrice = null;
                    priceModel.Price = string.Format(_localizationService.GetResource("Products.PriceRangeFrom"), _priceFormatter.FormatPrice(finalPrice));
                    priceModel.PriceValue = finalPrice;

                    //PAngV default baseprice (used in Germany)
                    priceModel.BasePricePAngV = _priceFormatter.FormatBasePrice(product, finalPriceBase);
                }
            }
            else
            {
                priceModel.OldPrice = null;
                priceModel.Price = null;
            }
        }

        /// <summary>
        /// 准备产品概述图片模型
        /// </summary>
        /// <param name="product"></param>
        /// <param name="productThumbPictureSize"></param>
        /// <returns></returns>
        protected virtual PictureModel PrepareProductOverviewPictureModel(Product product, int? productThumbPictureSize = null)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var productName = _localizationService.GetLocalized(product, x => x.Name);

            var pictureSize = productThumbPictureSize ?? _mediaSettings.ProductThumbPictureSize;

            var cacheKey = string.Format(NopModelCacheDefaults.ProductDefaultPictureModelKey,
                product.Id, pictureSize, true, _workContext.WorkingLanguage.Id, _webHelper.IsCurrentConnectionSecured(),
                _storeContext.CurrentStore.Id);

            var defaultPictureModel = _cacheManager.Get(cacheKey, () =>
               {
                   var picture = _pictureService.GetPicturesByProductId(product.Id, 1).FirstOrDefault();

                   var pictureModel = new PictureModel
                   {
                       ImageUrl = _pictureService.GetPictureUrl(picture, pictureSize),
                       FullSizeImageUrl = _pictureService.GetPictureUrl(picture),
                       Title = (picture != null && !string.IsNullOrEmpty(picture.TitleAttribute))
                       ? picture.TitleAttribute
                       : string.Format(_localizationService.GetResource("Media.Product.ImageLinkTitleFormat"), productName),

                       AlternateText = (picture != null && !string.IsNullOrEmpty(picture.AltAttribute))
                           ? picture.AltAttribute
                           : string.Format(_localizationService.GetResource("Media.Product.ImageAlternateTextFormat"),
                               productName)
                   };

                   return pictureModel;
               });
            return defaultPictureModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        protected virtual ProductReviewOverviewModel PrepareProductReviewOverviewModel(Product product)
        {
            ProductReviewOverviewModel productReview;

            if (_catalogSettings.ShowProductReviewsPerStore)
            {
                var cacheKey = string.Format(NopModelCacheDefaults.ProductReviewsModelKey, product.Id, _storeContext.CurrentStore.Id);

                productReview = _cacheManager.Get(cacheKey, () =>
                   {
                       return new ProductReviewOverviewModel
                       {
                           RatingSum = product.ProductReviews
                                   .Where(pr => pr.IsApproved && pr.StoreId == _storeContext.CurrentStore.Id)
                                   .Sum(pr => pr.Rating),
                           TotalReviews = product
                                   .ProductReviews
                                   .Count(pr => pr.IsApproved && pr.StoreId == _storeContext.CurrentStore.Id)
                       };
                   });

            }
            else
            {
                productReview = new ProductReviewOverviewModel()
                {
                    RatingSum = product.ApprovedRatingSum,
                    TotalReviews = product.ApprovedTotalReviews
                };
            }

            if (productReview != null)
            {
                productReview.ProductId = product.Id;
                productReview.AllowCustomerReviews = product.AllowCustomerReviews;
            }

            return productReview;
        }

        #endregion
    }
}

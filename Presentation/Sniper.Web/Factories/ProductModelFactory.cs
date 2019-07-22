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
using Sniper.Web.Models.Catalog;

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

        public IEnumerable<ProductOverviewModel> PrepareProductOverviewModels(IEnumerable<Product> products, bool preparePriceModel = true, bool preparePictureModel = true, int? productThumbPictureSize = null, bool prepareSpecificationAttributes = false, bool forceRedirectionAfterAddingToCart = false)
        {
            throw new NotImplementedException();
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
    }
}

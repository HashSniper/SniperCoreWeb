using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Domain.Blogs;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Common;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Forums;
using Sniper.Core.Domain.Media;
using Sniper.Core.Domain.Vendors;
using Sniper.Services.Catalog;
using Sniper.Services.Common;
using Sniper.Services.Directory;
using Sniper.Services.Events;
using Sniper.Services.Localization;
using Sniper.Services.Media;
using Sniper.Services.Seo;
using Sniper.Services.Topics;
using Sniper.Services.Vendors;
using Sniper.Web.Infrastructure.Cache;
using Sniper.Web.Models.Catalog;
using Sniper.Web.Models.Media;

namespace Sniper.Web.Factories
{
    public partial class CatalogModelFactory : ICatalogModelFactory
    {
        #region Fields

        private readonly BlogSettings _blogSettings;
        private readonly CatalogSettings _catalogSettings;
        private readonly DisplayDefaultMenuItemSettings _displayDefaultMenuItemSettings;
        private readonly ForumSettings _forumSettings;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryTemplateService _categoryTemplateService;
        private readonly ICurrencyService _currencyService;
        private readonly IEventPublisher _eventPublisher;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalizationService _localizationService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IManufacturerTemplateService _manufacturerTemplateService;
        private readonly IPictureService _pictureService;
        private readonly IPriceFormatter _priceFormatter;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IProductTagService _productTagService;
        private readonly ISearchTermService _searchTermService;
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreContext _storeContext;
        private readonly ITopicService _topicService;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IVendorService _vendorService;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly MediaSettings _mediaSettings;
        private readonly VendorSettings _vendorSettings;

        #endregion

        #region Ctor

        public CatalogModelFactory(BlogSettings blogSettings,
            CatalogSettings catalogSettings,
            DisplayDefaultMenuItemSettings displayDefaultMenuItemSettings,
            ForumSettings forumSettings,
            IActionContextAccessor actionContextAccessor,
            ICategoryService categoryService,
            ICategoryTemplateService categoryTemplateService,
            ICurrencyService currencyService,
            IEventPublisher eventPublisher,
            IHttpContextAccessor httpContextAccessor,
            ILocalizationService localizationService,
            IManufacturerService manufacturerService,
            IManufacturerTemplateService manufacturerTemplateService,
            IPictureService pictureService,
            IPriceFormatter priceFormatter,
            IProductModelFactory productModelFactory,
            IProductService productService,
            IProductTagService productTagService,
            ISearchTermService searchTermService,
            ISpecificationAttributeService specificationAttributeService,
            IStaticCacheManager cacheManager,
            IStoreContext storeContext,
            ITopicService topicService,
            IUrlHelperFactory urlHelperFactory,
            IUrlRecordService urlRecordService,
            IVendorService vendorService,
            IWebHelper webHelper,
            IWorkContext workContext,
            MediaSettings mediaSettings,
            VendorSettings vendorSettings)
        {
            _blogSettings = blogSettings;
            _catalogSettings = catalogSettings;
            _displayDefaultMenuItemSettings = displayDefaultMenuItemSettings;
            _forumSettings = forumSettings;
            _actionContextAccessor = actionContextAccessor;
            _categoryService = categoryService;
            _categoryTemplateService = categoryTemplateService;
            _currencyService = currencyService;
            _eventPublisher = eventPublisher;
            _httpContextAccessor = httpContextAccessor;
            _localizationService = localizationService;
            _manufacturerService = manufacturerService;
            _manufacturerTemplateService = manufacturerTemplateService;
            _pictureService = pictureService;
            _priceFormatter = priceFormatter;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _productTagService = productTagService;
            _searchTermService = searchTermService;
            _specificationAttributeService = specificationAttributeService;
            _cacheManager = cacheManager;
            _storeContext = storeContext;
            _topicService = topicService;
            _urlHelperFactory = urlHelperFactory;
            _urlRecordService = urlRecordService;
            _vendorService = vendorService;
            _webHelper = webHelper;
            _workContext = workContext;
            _mediaSettings = mediaSettings;
            _vendorSettings = vendorSettings;
        }

        #endregion


        #region Methods
        public CategoryModel PrepareCategoryModel(Category category, CatalogPagingFilteringModel command)
        {
            throw new NotImplementedException();
        }

        public CategoryNavigationModel PrepareCategoryNavigationModel(int currentCategoryId, int currentProductId)
        {
            throw new NotImplementedException();
        }

        public List<CategorySimpleModel> PrepareCategorySimpleModels()
        {
            throw new NotImplementedException();
        }

        public List<CategorySimpleModel> PrepareCategorySimpleModels(int rootCategoryId, bool loadSubCategories = true)
        {
            throw new NotImplementedException();
        }

        public string PrepareCategoryTemplateViewPath(int templateId)
        {
            throw new NotImplementedException();
        }

        public XDocument PrepareCategoryXmlDocument()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 准备主页类别模型
        /// </summary>
        /// <returns></returns>
        public virtual List<CategoryModel> PrepareHomepageCategoryModels()
        {
            var pictureSize = _mediaSettings.CategoryThumbPictureSize;
            var categoriesCacheKey = string.Format(NopModelCacheDefaults.CategoryHomepageKey,
                string.Join(",", _workContext.CurrentCustomer.GetCustomerRoleIds()),
                pictureSize,
                _storeContext.CurrentStore.Id,
                _workContext.WorkingLanguage.Id,
                _webHelper.IsCurrentConnectionSecured());

            var model = _cacheManager.Get(categoriesCacheKey, () =>
               _categoryService.GetAllCategoriesDisplayedOnHomepage()
               .Select(category =>
               {
                   var catModel = new CategoryModel
                   {
                       Id = category.Id,
                       Name = _localizationService.GetLocalized(category, x => x.Name),
                       Description = _localizationService.GetLocalized(category, x => x.Description),
                       MetaKeywords = _localizationService.GetLocalized(category, x => x.MetaKeywords),
                       MetaDescription = _localizationService.GetLocalized(category, x => x.MetaDescription),
                       MetaTitle = _localizationService.GetLocalized(category, x => x.MetaTitle),
                       SeName = _urlRecordService.GetSeName(category)
                   };

                   var categoryPictureCacheKey = string.Format(NopModelCacheDefaults.CategoryPictureModelKey, category.Id, pictureSize, true, _workContext.WorkingLanguage.Id, _webHelper.IsCurrentConnectionSecured(), _storeContext.CurrentStore.Id);
                   catModel.PictureModel = _cacheManager.Get(categoryPictureCacheKey, () =>
                   {
                       var picture = _pictureService.GetPictureById(category.PictureId);
                       var pictureModel = new PictureModel
                       {
                           FullSizeImageUrl = _pictureService.GetPictureUrl(picture),
                           ImageUrl = _pictureService.GetPictureUrl(picture, pictureSize),
                           Title = string.Format(_localizationService.GetResource("Media.Category.ImageLinkTitleFormat"), catModel.Name),
                           AlternateText = string.Format(_localizationService.GetResource("Media.Category.ImageAlternateTextFormat"), catModel.Name)
                       };
                       return pictureModel;
                   });

                   return catModel;
               }).ToList()
               );
            return model;
        }

        public List<ManufacturerModel> PrepareManufacturerAllModels()
        {
            throw new NotImplementedException();
        }

        public ManufacturerModel PrepareManufacturerModel(Manufacturer manufacturer, CatalogPagingFilteringModel command)
        {
            throw new NotImplementedException();
        }

        public ManufacturerNavigationModel PrepareManufacturerNavigationModel(int currentManufacturerId)
        {
            throw new NotImplementedException();
        }

        public string PrepareManufacturerTemplateViewPath(int templateId)
        {
            throw new NotImplementedException();
        }

        public void PreparePageSizeOptions(CatalogPagingFilteringModel pagingFilteringModel, CatalogPagingFilteringModel command, bool allowCustomersToSelectPageSize, string pageSizeOptions, int fixedPageSize)
        {
            throw new NotImplementedException();
        }

        public PopularProductTagsModel PreparePopularProductTagsModel()
        {
            throw new NotImplementedException();
        }

        public ProductsByTagModel PrepareProductsByTagModel(ProductTag productTag, CatalogPagingFilteringModel command)
        {
            throw new NotImplementedException();
        }

        public PopularProductTagsModel PrepareProductTagsAllModel()
        {
            throw new NotImplementedException();
        }

        public List<CategorySimpleModel> PrepareRootCategories()
        {
            throw new NotImplementedException();
        }

        public SearchBoxModel PrepareSearchBoxModel()
        {
            throw new NotImplementedException();
        }

        public SearchModel PrepareSearchModel(SearchModel model, CatalogPagingFilteringModel command)
        {
            throw new NotImplementedException();
        }

        public void PrepareSortingOptions(CatalogPagingFilteringModel pagingFilteringModel, CatalogPagingFilteringModel command)
        {
            throw new NotImplementedException();
        }

        public List<CategorySimpleModel> PrepareSubCategories(int id)
        {
            throw new NotImplementedException();
        }

        public TopMenuModel PrepareTopMenuModel()
        {
            throw new NotImplementedException();
        }

        public List<VendorModel> PrepareVendorAllModels()
        {
            throw new NotImplementedException();
        }

        public VendorModel PrepareVendorModel(Vendor vendor, CatalogPagingFilteringModel command)
        {
            throw new NotImplementedException();
        }

        public VendorNavigationModel PrepareVendorNavigationModel()
        {
            throw new NotImplementedException();
        }

        public void PrepareViewModes(CatalogPagingFilteringModel pagingFilteringModel, CatalogPagingFilteringModel command)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

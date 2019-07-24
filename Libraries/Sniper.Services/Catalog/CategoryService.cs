using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Common;
using Sniper.Core.Domain.Security;
using Sniper.Core.Domain.Stores;
using Sniper.Data;
using Sniper.Services.Events;
using Sniper.Services.Localization;
using Sniper.Services.Security;
using Sniper.Services.Stores;
using System.Linq;

namespace Sniper.Services.Catalog
{
    public partial class CategoryService : ICategoryService
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly CommonSettings _commonSettings;
        private readonly IAclService _aclService;
        private readonly ICacheManager _cacheManager;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<AclRecord> _aclRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly IRepository<StoreMapping> _storeMappingRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public CategoryService(CatalogSettings catalogSettings,
            CommonSettings commonSettings,
            IAclService aclService,
            ICacheManager cacheManager,
            IDataProvider dataProvider,
            IDbContext dbContext,
            IEventPublisher eventPublisher,
            ILocalizationService localizationService,
            IRepository<AclRecord> aclRepository,
            IRepository<Category> categoryRepository,
            IRepository<Product> productRepository,
            IRepository<ProductCategory> productCategoryRepository,
            IRepository<StoreMapping> storeMappingRepository,
            IStaticCacheManager staticCacheManager,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IWorkContext workContext)
        {
            _catalogSettings = catalogSettings;
            _commonSettings = commonSettings;
            _aclService = aclService;
            _cacheManager = cacheManager;
            _dataProvider = dataProvider;
            _dbContext = dbContext;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _aclRepository = aclRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _storeMappingRepository = storeMappingRepository;
            _staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _workContext = workContext;
        }

        #endregion


        #region Methods
        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductCategory(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }

        public ProductCategory FindProductCategory(IList<ProductCategory> source, int productId, int categoryId)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetAllCategories(int storeId = 0, bool showHidden = false, bool loadCacheableCopy = true)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Category> GetAllCategories(string categoryName, int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取主页上显示的所有类别
        /// </summary>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public IList<Category> GetAllCategoriesDisplayedOnHomepage(bool showHidden = false)
        {
            var query = from c in _categoryRepository.Table
                        orderby c.DisplayOrder, c.Id
                        where c.Published && !c.Deleted && c.ShowOnHomepage
                        select c;

            var categories = query.ToList();

            if (!showHidden)
            {
                categories = categories
                    .Where(c => _aclService.Authorize(c) && _storeMappingService.Authorize(c))
                    .ToList();
            }

            return categories;


        }

        public List<Category> GetCategoriesByIds(int[] categoryIds)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetCategoryBreadCrumb(Category category, IList<Category> allCategories = null, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IList<int> GetChildCategoryIds(int parentCategoryId, int storeId = 0, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public string GetFormattedBreadCrumb(Category category, IList<Category> allCategories = null, string separator = ">>", int languageId = 0)
        {
            throw new NotImplementedException();
        }

        public string[] GetNotExistingCategories(string[] categoryIdsNames)
        {
            throw new NotImplementedException();
        }

        public IPagedList<ProductCategory> GetProductCategoriesByCategoryId(int categoryId, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public IList<ProductCategory> GetProductCategoriesByProductId(int productId, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public IList<ProductCategory> GetProductCategoriesByProductId(int productId, int storeId, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetProductCategoryById(int productCategoryId)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, int[]> GetProductCategoryIds(int[] productIds)
        {
            throw new NotImplementedException();
        }

        public void InsertCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void InsertProductCategory(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }

        public IList<Category> SortCategoriesForTree(IList<Category> source, int parentId = 0, bool ignoreCategoriesWithoutExistingParent = false)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductCategory(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

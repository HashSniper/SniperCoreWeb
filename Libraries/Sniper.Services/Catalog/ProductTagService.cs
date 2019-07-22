using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Data;
using Sniper.Services.Events;
using Sniper.Services.Seo;

namespace Sniper.Services.Catalog
{
    public partial class ProductTagService : IProductTagService
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly ICacheManager _cacheManager;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IEventPublisher _eventPublisher;
        private readonly IProductService _productService;
        private readonly IRepository<ProductProductTagMapping> _productProductTagMappingRepository;
        private readonly IRepository<ProductTag> _productTagRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public ProductTagService(CatalogSettings catalogSettings,
            ICacheManager cacheManager,
            IDataProvider dataProvider,
            IDbContext dbContext,
            IEventPublisher eventPublisher,
            IProductService productService,
            IRepository<ProductProductTagMapping> productProductTagMappingRepository,
            IRepository<ProductTag> productTagRepository,
            IStaticCacheManager staticCacheManager,
            IUrlRecordService urlRecordService,
            IWorkContext workContext)
        {
            _catalogSettings = catalogSettings;
            _cacheManager = cacheManager;
            _dataProvider = dataProvider;
            _dbContext = dbContext;
            _eventPublisher = eventPublisher;
            _productService = productService;
            _productProductTagMappingRepository = productProductTagMappingRepository;
            _productTagRepository = productTagRepository;
            _staticCacheManager = staticCacheManager;
            _urlRecordService = urlRecordService;
            _workContext = workContext;
        }

        #endregion

        #region Methods
        public void DeleteProductTag(ProductTag productTag)
        {
            throw new NotImplementedException();
        }

        public IList<ProductTag> GetAllProductTags()
        {
            throw new NotImplementedException();
        }

        public IList<ProductTag> GetAllProductTagsByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public int GetProductCount(int productTagId, int storeId, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public ProductTag GetProductTagById(int productTagId)
        {
            throw new NotImplementedException();
        }

        public ProductTag GetProductTagByName(string name)
        {
            throw new NotImplementedException();
        }

        public void InsertProductTag(ProductTag productTag)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductTag(ProductTag productTag)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductTags(Product product, string[] productTags)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

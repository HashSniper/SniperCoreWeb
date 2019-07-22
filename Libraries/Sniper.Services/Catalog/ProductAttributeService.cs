using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Services.Events;

namespace Sniper.Services.Catalog
{
    public partial class ProductAttributeService : IProductAttributeService
    {
        #region Fields

        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<PredefinedProductAttributeValue> _predefinedProductAttributeValueRepository;
        private readonly IRepository<ProductAttribute> _productAttributeRepository;
        private readonly IRepository<ProductAttributeCombination> _productAttributeCombinationRepository;
        private readonly IRepository<ProductAttributeMapping> _productAttributeMappingRepository;
        private readonly IRepository<ProductAttributeValue> _productAttributeValueRepository;
        private readonly IStaticCacheManager _staticCacheManager;

        #endregion

        #region Ctor

        public ProductAttributeService(ICacheManager cacheManager,
            IEventPublisher eventPublisher,
            IRepository<PredefinedProductAttributeValue> predefinedProductAttributeValueRepository,
            IRepository<ProductAttribute> productAttributeRepository,
            IRepository<ProductAttributeCombination> productAttributeCombinationRepository,
            IRepository<ProductAttributeMapping> productAttributeMappingRepository,
            IRepository<ProductAttributeValue> productAttributeValueRepository,
            IStaticCacheManager staticCacheManager)
        {
            _cacheManager = cacheManager;
            _eventPublisher = eventPublisher;
            _predefinedProductAttributeValueRepository = predefinedProductAttributeValueRepository;
            _productAttributeRepository = productAttributeRepository;
            _productAttributeCombinationRepository = productAttributeCombinationRepository;
            _productAttributeMappingRepository = productAttributeMappingRepository;
            _productAttributeValueRepository = productAttributeValueRepository;
            _staticCacheManager = staticCacheManager;
        }

        #endregion

        #region Methods
        public void DeletePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductAttribute(ProductAttribute productAttribute)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductAttributeCombination(ProductAttributeCombination combination)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductAttributeMapping(ProductAttributeMapping productAttributeMapping)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            throw new NotImplementedException();
        }

        public IList<ProductAttributeCombination> GetAllProductAttributeCombinations(int productId)
        {
            throw new NotImplementedException();
        }

        public IPagedList<ProductAttribute> GetAllProductAttributes(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public int[] GetNotExistingAttributes(int[] attributeId)
        {
            throw new NotImplementedException();
        }

        public PredefinedProductAttributeValue GetPredefinedProductAttributeValueById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<PredefinedProductAttributeValue> GetPredefinedProductAttributeValues(int productAttributeId)
        {
            throw new NotImplementedException();
        }

        public ProductAttribute GetProductAttributeById(int productAttributeId)
        {
            throw new NotImplementedException();
        }

        public ProductAttributeCombination GetProductAttributeCombinationById(int productAttributeCombinationId)
        {
            throw new NotImplementedException();
        }

        public ProductAttributeCombination GetProductAttributeCombinationBySku(string sku)
        {
            throw new NotImplementedException();
        }

        public ProductAttributeMapping GetProductAttributeMappingById(int productAttributeMappingId)
        {
            throw new NotImplementedException();
        }

        public IList<ProductAttributeMapping> GetProductAttributeMappingsByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public ProductAttributeValue GetProductAttributeValueById(int productAttributeValueId)
        {
            throw new NotImplementedException();
        }

        public IList<ProductAttributeValue> GetProductAttributeValues(int productAttributeMappingId)
        {
            throw new NotImplementedException();
        }

        public void InsertPredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            throw new NotImplementedException();
        }

        public void InsertProductAttribute(ProductAttribute productAttribute)
        {
            throw new NotImplementedException();
        }

        public void InsertProductAttributeCombination(ProductAttributeCombination combination)
        {
            throw new NotImplementedException();
        }

        public void InsertProductAttributeMapping(ProductAttributeMapping productAttributeMapping)
        {
            throw new NotImplementedException();
        }

        public void InsertProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            throw new NotImplementedException();
        }

        public void UpdatePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductAttribute(ProductAttribute productAttribute)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductAttributeCombination(ProductAttributeCombination combination)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductAttributeMapping(ProductAttributeMapping productAttributeMapping)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

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
    /// <summary>
    /// 规范属性服务
    /// </summary>
    public partial class SpecificationAttributeService : ISpecificationAttributeService
    {
        #region Fields

        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<ProductSpecificationAttribute> _productSpecificationAttributeRepository;
        private readonly IRepository<SpecificationAttribute> _specificationAttributeRepository;
        private readonly IRepository<SpecificationAttributeOption> _specificationAttributeOptionRepository;

        #endregion

        #region Ctor

        public SpecificationAttributeService(ICacheManager cacheManager,
            IEventPublisher eventPublisher,
            IRepository<ProductSpecificationAttribute> productSpecificationAttributeRepository,
            IRepository<SpecificationAttribute> specificationAttributeRepository,
            IRepository<SpecificationAttributeOption> specificationAttributeOptionRepository)
        {
            _cacheManager = cacheManager;
            _eventPublisher = eventPublisher;
            _productSpecificationAttributeRepository = productSpecificationAttributeRepository;
            _specificationAttributeRepository = specificationAttributeRepository;
            _specificationAttributeOptionRepository = specificationAttributeOptionRepository;
        }

        #endregion

        #region Methods
        public void DeleteProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            throw new NotImplementedException();
        }

        public int[] GetNotExistingSpecificationAttributeOptions(int[] attributeOptionIds)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Product> GetProductsBySpecificationAttributeId(int specificationAttributeId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public ProductSpecificationAttribute GetProductSpecificationAttributeById(int productSpecificationAttributeId)
        {
            throw new NotImplementedException();
        }

        public int GetProductSpecificationAttributeCount(int productId = 0, int specificationAttributeOptionId = 0)
        {
            throw new NotImplementedException();
        }

        public IList<ProductSpecificationAttribute> GetProductSpecificationAttributes(int productId = 0, int specificationAttributeOptionId = 0, bool? allowFiltering = null, bool? showOnProductPage = null)
        {
            throw new NotImplementedException();
        }

        public SpecificationAttribute GetSpecificationAttributeById(int specificationAttributeId)
        {
            throw new NotImplementedException();
        }

        public SpecificationAttributeOption GetSpecificationAttributeOptionById(int specificationAttributeOption)
        {
            throw new NotImplementedException();
        }

        public IList<SpecificationAttributeOption> GetSpecificationAttributeOptionsByIds(int[] specificationAttributeOptionIds)
        {
            throw new NotImplementedException();
        }

        public IList<SpecificationAttributeOption> GetSpecificationAttributeOptionsBySpecificationAttribute(int specificationAttributeId)
        {
            throw new NotImplementedException();
        }

        public IPagedList<SpecificationAttribute> GetSpecificationAttributes(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IList<SpecificationAttribute> GetSpecificationAttributesWithOptions()
        {
            throw new NotImplementedException();
        }

        public void InsertProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute)
        {
            throw new NotImplementedException();
        }

        public void InsertSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            throw new NotImplementedException();
        }

        public void InsertSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute)
        {
            throw new NotImplementedException();
        }

        public void UpdateSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            throw new NotImplementedException();
        }

        public void UpdateSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

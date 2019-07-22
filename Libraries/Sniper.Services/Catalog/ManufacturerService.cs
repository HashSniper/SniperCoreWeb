using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Security;
using Sniper.Core.Domain.Stores;
using Sniper.Services.Events;

namespace Sniper.Services.Catalog
{
    public partial class ManufacturerService : IManufacturerService
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<AclRecord> _aclRepository;
        private readonly IRepository<Manufacturer> _manufacturerRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductManufacturer> _productManufacturerRepository;
        private readonly IRepository<StoreMapping> _storeMappingRepository;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public ManufacturerService(CatalogSettings catalogSettings,
            ICacheManager cacheManager,
            IEventPublisher eventPublisher,
            IRepository<AclRecord> aclRepository,
            IRepository<Manufacturer> manufacturerRepository,
            IRepository<Product> productRepository,
            IRepository<ProductManufacturer> productManufacturerRepository,
            IRepository<StoreMapping> storeMappingRepository,
            IStoreContext storeContext,
            IWorkContext workContext)
        {
            _catalogSettings = catalogSettings;
            _cacheManager = cacheManager;
            _eventPublisher = eventPublisher;
            _aclRepository = aclRepository;
            _manufacturerRepository = manufacturerRepository;
            _productRepository = productRepository;
            _productManufacturerRepository = productManufacturerRepository;
            _storeMappingRepository = storeMappingRepository;
            _storeContext = storeContext;
            _workContext = workContext;
        }

        #endregion


        #region Methods
        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductManufacturer(ProductManufacturer productManufacturer)
        {
            throw new NotImplementedException();
        }

        public ProductManufacturer FindProductManufacturer(IList<ProductManufacturer> source, int productId, int manufacturerId)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Manufacturer> GetAllManufacturers(string manufacturerName = "", int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public Manufacturer GetManufacturerById(int manufacturerId)
        {
            throw new NotImplementedException();
        }

        public string[] GetNotExistingManufacturers(string[] manufacturerIdsNames)
        {
            throw new NotImplementedException();
        }

        public ProductManufacturer GetProductManufacturerById(int productManufacturerId)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, int[]> GetProductManufacturerIds(int[] productIds)
        {
            throw new NotImplementedException();
        }

        public IPagedList<ProductManufacturer> GetProductManufacturersByManufacturerId(int manufacturerId, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public IList<ProductManufacturer> GetProductManufacturersByProductId(int productId, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public void InsertManufacturer(Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }

        public void InsertProductManufacturer(ProductManufacturer productManufacturer)
        {
            throw new NotImplementedException();
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductManufacturer(ProductManufacturer productManufacturer)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

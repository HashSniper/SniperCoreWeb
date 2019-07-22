using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Common;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Orders;
using Sniper.Core.Domain.Security;
using Sniper.Core.Domain.Shipping;
using Sniper.Core.Domain.Stores;
using Sniper.Data;
using Sniper.Services.Events;
using Sniper.Services.Localization;
using Sniper.Services.Security;
using Sniper.Services.Shipping.Date;
using Sniper.Services.Stores;

namespace Sniper.Services.Catalog
{
    public partial class ProductService : IProductService
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly CommonSettings _commonSettings;
        private readonly IAclService _aclService;
        private readonly ICacheManager _cacheManager;
        private readonly IDataProvider _dataProvider;
        private readonly IDateRangeService _dateRangeService;
        private readonly IDbContext _dbContext;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;
        private readonly IProductAttributeParser _productAttributeParser;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IRepository<AclRecord> _aclRepository;
        private readonly IRepository<CrossSellProduct> _crossSellProductRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductPicture> _productPictureRepository;
        private readonly IRepository<ProductReview> _productReviewRepository;
        private readonly IRepository<ProductWarehouseInventory> _productWarehouseInventoryRepository;
        private readonly IRepository<RelatedProduct> _relatedProductRepository;
        private readonly IRepository<StockQuantityHistory> _stockQuantityHistoryRepository;
        private readonly IRepository<StoreMapping> _storeMappingRepository;
        private readonly IRepository<TierPrice> _tierPriceRepository;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IStoreService _storeService;
        private readonly IWorkContext _workContext;
        private readonly LocalizationSettings _localizationSettings;

        #endregion

        #region Ctor

        public ProductService(CatalogSettings catalogSettings,
            CommonSettings commonSettings,
            IAclService aclService,
            ICacheManager cacheManager,
            IDataProvider dataProvider,
            IDateRangeService dateRangeService,
            IDbContext dbContext,
            IEventPublisher eventPublisher,
            ILanguageService languageService,
            ILocalizationService localizationService,
            IProductAttributeParser productAttributeParser,
            IProductAttributeService productAttributeService,
            IRepository<AclRecord> aclRepository,
            IRepository<CrossSellProduct> crossSellProductRepository,
            IRepository<Product> productRepository,
            IRepository<ProductPicture> productPictureRepository,
            IRepository<ProductReview> productReviewRepository,
            IRepository<ProductWarehouseInventory> productWarehouseInventoryRepository,
            IRepository<RelatedProduct> relatedProductRepository,
            IRepository<StockQuantityHistory> stockQuantityHistoryRepository,
            IRepository<StoreMapping> storeMappingRepository,
            IRepository<TierPrice> tierPriceRepository,
            IStoreService storeService,
            IStoreMappingService storeMappingService,
            IWorkContext workContext,
            LocalizationSettings localizationSettings)
        {
            _catalogSettings = catalogSettings;
            _commonSettings = commonSettings;
            _aclService = aclService;
            _cacheManager = cacheManager;
            _dataProvider = dataProvider;
            _dateRangeService = dateRangeService;
            _dbContext = dbContext;
            _eventPublisher = eventPublisher;
            _languageService = languageService;
            _localizationService = localizationService;
            _productAttributeParser = productAttributeParser;
            _productAttributeService = productAttributeService;
            _aclRepository = aclRepository;
            _crossSellProductRepository = crossSellProductRepository;
            _productRepository = productRepository;
            _productPictureRepository = productPictureRepository;
            _productReviewRepository = productReviewRepository;
            _productWarehouseInventoryRepository = productWarehouseInventoryRepository;
            _relatedProductRepository = relatedProductRepository;
            _stockQuantityHistoryRepository = stockQuantityHistoryRepository;
            _storeMappingRepository = storeMappingRepository;
            _tierPriceRepository = tierPriceRepository;
            _storeMappingService = storeMappingService;
            _storeService = storeService;
            _workContext = workContext;
            _localizationSettings = localizationSettings;
        }

        #endregion

        #region Methods
        public void AddStockQuantityHistoryEntry(Product product, int quantityAdjustment, int stockQuantity, int warehouseId = 0, string message = "", int? combinationId = null)
        {
            throw new NotImplementedException();
        }

        public void AdjustInventory(Product product, int quantityToChange, string attributesXml = "", string message = "")
        {
            throw new NotImplementedException();
        }

        public void BookReservedInventory(Product product, int warehouseId, int quantity, string message = "")
        {
            throw new NotImplementedException();
        }

        public void DeleteCrossSellProduct(CrossSellProduct crossSellProduct)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductPicture(ProductPicture productPicture)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductReview(ProductReview productReview)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductReviews(IList<ProductReview> productReviews)
        {
            throw new NotImplementedException();
        }

        public void DeleteProducts(IList<Product> products)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductWarehouseInventory(ProductWarehouseInventory pwi)
        {
            throw new NotImplementedException();
        }

        public void DeleteRelatedProduct(RelatedProduct relatedProduct)
        {
            throw new NotImplementedException();
        }

        public void DeleteTierPrice(TierPrice tierPrice)
        {
            throw new NotImplementedException();
        }

        public CrossSellProduct FindCrossSellProduct(IList<CrossSellProduct> source, int productId1, int productId2)
        {
            throw new NotImplementedException();
        }

        public RelatedProduct FindRelatedProduct(IList<RelatedProduct> source, int productId1, int productId2)
        {
            throw new NotImplementedException();
        }

        public string FormatGtin(Product product, string attributesXml = null)
        {
            throw new NotImplementedException();
        }

        public string FormatMpn(Product product, string attributesXml = null)
        {
            throw new NotImplementedException();
        }

        public string FormatRentalDate(Product product, DateTime date)
        {
            throw new NotImplementedException();
        }

        public string FormatSku(Product product, string attributesXml = null)
        {
            throw new NotImplementedException();
        }

        public string FormatStockMessage(Product product, string attributesXml)
        {
            throw new NotImplementedException();
        }

        public IPagedList<ProductReview> GetAllProductReviews(int customerId, bool? approved, DateTime? fromUtc = null, DateTime? toUtc = null, string message = null, int storeId = 0, int productId = 0, int vendorId = 0, bool showHidden = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAllProductsDisplayedOnHomepage()
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAssociatedProducts(int parentGroupedProductId, int storeId = 0, int vendorId = 0, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public CrossSellProduct GetCrossSellProductById(int crossSellProductId)
        {
            throw new NotImplementedException();
        }

        public IList<CrossSellProduct> GetCrossSellProductsByProductId1(int productId1, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public IList<CrossSellProduct> GetCrossSellProductsByProductIds(int[] productIds, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetCrosssellProductsByShoppingCart(IList<ShoppingCartItem> cart, int numberOfProducts)
        {
            throw new NotImplementedException();
        }

        public IPagedList<ProductAttributeCombination> GetLowStockProductCombinations(int? vendorId = null, bool? loadPublishedOnly = true, int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Product> GetLowStockProducts(int? vendorId = null, bool? loadPublishedOnly = true, int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfProductsByVendorId(int vendorId)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfProductsInCategory(IList<int> categoryIds = null, int storeId = 0)
        {
            throw new NotImplementedException();
        }

        public TierPrice GetPreferredTierPrice(Product product, Customer customer, int storeId, int quantity)
        {
            throw new NotImplementedException();
        }

        public IList<ProductReview> GetProducReviewsByIds(int[] productReviewIds)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductBySku(string sku)
        {
            throw new NotImplementedException();
        }

        public ProductPicture GetProductPictureById(int productPictureId)
        {
            throw new NotImplementedException();
        }

        public IList<ProductPicture> GetProductPicturesByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public ProductReview GetProductReviewById(int productReviewId)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProductsByIds(int[] productIds)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Product> GetProductsByProductAtributeId(int productAttributeId, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProductsBySku(string[] skuArray, int vendorId = 0)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, int[]> GetProductsImagesIds(int[] productsIds)
        {
            throw new NotImplementedException();
        }

        public RelatedProduct GetRelatedProductById(int relatedProductId)
        {
            throw new NotImplementedException();
        }

        public IList<RelatedProduct> GetRelatedProductsByProductId1(int productId1, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public int GetRentalPeriods(Product product, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public IPagedList<StockQuantityHistory> GetStockQuantityHistory(Product product, int warehouseId = 0, int combinationId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public TierPrice GetTierPriceById(int tierPriceId)
        {
            throw new NotImplementedException();
        }

        public int GetTotalStockQuantity(Product product, bool useReservedQuantity = true, int warehouseId = 0)
        {
            throw new NotImplementedException();
        }

        public void InsertCrossSellProduct(CrossSellProduct crossSellProduct)
        {
            throw new NotImplementedException();
        }

        public void InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void InsertProductPicture(ProductPicture productPicture)
        {
            throw new NotImplementedException();
        }

        public void InsertRelatedProduct(RelatedProduct relatedProduct)
        {
            throw new NotImplementedException();
        }

        public void InsertTierPrice(TierPrice tierPrice)
        {
            throw new NotImplementedException();
        }

        public int[] ParseAllowedQuantities(Product product)
        {
            throw new NotImplementedException();
        }

        public int[] ParseRequiredProductIds(Product product)
        {
            throw new NotImplementedException();
        }

        public bool ProductIsAvailable(Product product, DateTime? dateTime = null)
        {
            throw new NotImplementedException();
        }

        public bool ProductTagExists(Product product, int productTagId)
        {
            throw new NotImplementedException();
        }

        public void ReserveInventory(Product product, int quantity)
        {
            throw new NotImplementedException();
        }

        public int ReverseBookedInventory(Product product, ShipmentItem shipmentItem, string message = "")
        {
            throw new NotImplementedException();
        }

        public IPagedList<Product> SearchProducts(int pageIndex = 0, int pageSize = int.MaxValue, IList<int> categoryIds = null, int manufacturerId = 0, int storeId = 0, int vendorId = 0, int warehouseId = 0, ProductType? productType = null, bool visibleIndividuallyOnly = false, bool markedAsNewOnly = false, bool? featuredProducts = null, decimal? priceMin = null, decimal? priceMax = null, int productTagId = 0, string keywords = null, bool searchDescriptions = false, bool searchManufacturerPartNumber = true, bool searchSku = true, bool searchProductTags = false, int languageId = 0, IList<int> filteredSpecs = null, ProductSortingEnum orderBy = ProductSortingEnum.Position, bool showHidden = false, bool? overridePublished = null)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Product> SearchProducts(out IList<int> filterableSpecificationAttributeOptionIds, bool loadFilterableSpecificationAttributeOptionIds = false, int pageIndex = 0, int pageSize = int.MaxValue, IList<int> categoryIds = null, int manufacturerId = 0, int storeId = 0, int vendorId = 0, int warehouseId = 0, ProductType? productType = null, bool visibleIndividuallyOnly = false, bool markedAsNewOnly = false, bool? featuredProducts = null, decimal? priceMin = null, decimal? priceMax = null, int productTagId = 0, string keywords = null, bool searchDescriptions = false, bool searchManufacturerPartNumber = true, bool searchSku = true, bool searchProductTags = false, int languageId = 0, IList<int> filteredSpecs = null, ProductSortingEnum orderBy = ProductSortingEnum.Position, bool showHidden = false, bool? overridePublished = null)
        {
            throw new NotImplementedException();
        }

        public void UnblockReservedInventory(Product product, int quantity)
        {
            throw new NotImplementedException();
        }

        public void UpdateCrossSellProduct(CrossSellProduct crossSellProduct)
        {
            throw new NotImplementedException();
        }

        public void UpdateHasDiscountsApplied(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateHasTierPricesProperty(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductPicture(ProductPicture productPicture)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductReviewTotals(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProducts(IList<Product> products)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductStoreMappings(Product product, IList<int> limitedToStoresIds)
        {
            throw new NotImplementedException();
        }

        public void UpdateRelatedProduct(RelatedProduct relatedProduct)
        {
            throw new NotImplementedException();
        }

        public void UpdateTierPrice(TierPrice tierPrice)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

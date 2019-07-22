using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Discounts;
using Sniper.Services.Catalog;
using Sniper.Services.Customers;
using Sniper.Services.Events;
using Sniper.Services.Localization;

namespace Sniper.Services.Discounts
{
    public partial class DiscountService : IDiscountService
    {
        #region Fields

        private readonly ICategoryService _categoryService;
        private readonly ICustomerService _customerService;
        private readonly IDiscountPluginManager _discountPluginManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Discount> _discountRepository;
        private readonly IRepository<DiscountRequirement> _discountRequirementRepository;
        private readonly IRepository<DiscountUsageHistory> _discountUsageHistoryRepository;
        private readonly IRepository<Manufacturer> _manufacturerRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreContext _storeContext;

        #endregion

        #region Ctor

        public DiscountService(ICategoryService categoryService,
            ICustomerService customerService,
            IDiscountPluginManager discountPluginManager,
            IEventPublisher eventPublisher,
            ILocalizationService localizationService,
            IRepository<Category> categoryRepository,
            IRepository<Discount> discountRepository,
            IRepository<DiscountRequirement> discountRequirementRepository,
            IRepository<DiscountUsageHistory> discountUsageHistoryRepository,
            IRepository<Manufacturer> manufacturerRepository,
            IRepository<Product> productRepository,
            IStaticCacheManager cacheManager,
            IStoreContext storeContext)
        {
            _categoryService = categoryService;
            _customerService = customerService;
            _discountPluginManager = discountPluginManager;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _categoryRepository = categoryRepository;
            _discountRepository = discountRepository;
            _discountRequirementRepository = discountRequirementRepository;
            _discountUsageHistoryRepository = discountUsageHistoryRepository;
            _manufacturerRepository = manufacturerRepository;
            _productRepository = productRepository;
            _cacheManager = cacheManager;
            _storeContext = storeContext;
        }

        #endregion


        #region Methods
        public bool ContainsDiscount(IList<DiscountForCaching> discounts, DiscountForCaching discount)
        {
            throw new NotImplementedException();
        }

        public void DeleteDiscount(Discount discount)
        {
            throw new NotImplementedException();
        }

        public void DeleteDiscountRequirement(DiscountRequirement discountRequirement)
        {
            throw new NotImplementedException();
        }

        public void DeleteDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            throw new NotImplementedException();
        }

        public IList<DiscountRequirement> GetAllDiscountRequirements(int discountId = 0, bool topLevelOnly = false)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllDiscounts(DiscountType? discountType = null, string couponCode = null, string discountName = null, bool showHidden = false, DateTime? startDateUtc = null, DateTime? endDateUtc = null)
        {
            throw new NotImplementedException();
        }

        public IList<DiscountForCaching> GetAllDiscountsForCaching(DiscountType? discountType = null, string couponCode = null, string discountName = null, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public IPagedList<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId = null, int? customerId = null, int? orderId = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IList<int> GetAppliedCategoryIds(DiscountForCaching discount, Customer customer)
        {
            throw new NotImplementedException();
        }

        public IList<int> GetAppliedManufacturerIds(DiscountForCaching discount, Customer customer)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Category> GetCategoriesWithAppliedDiscount(int? discountId = null, bool showHidden = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public decimal GetDiscountAmount(DiscountForCaching discount, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Discount GetDiscountById(int discountId)
        {
            throw new NotImplementedException();
        }

        public DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryId)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Manufacturer> GetManufacturersWithAppliedDiscount(int? discountId = null, bool showHidden = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public List<DiscountForCaching> GetPreferredDiscount(IList<DiscountForCaching> discounts, decimal amount, out decimal discountAmount)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Product> GetProductsWithAppliedDiscount(int? discountId = null, bool showHidden = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public void InsertDiscount(Discount discount)
        {
            throw new NotImplementedException();
        }

        public void InsertDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            throw new NotImplementedException();
        }

        public DiscountForCaching MapDiscount(Discount discount)
        {
            throw new NotImplementedException();
        }

        public void UpdateDiscount(Discount discount)
        {
            throw new NotImplementedException();
        }

        public void UpdateDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            throw new NotImplementedException();
        }

        public DiscountValidationResult ValidateDiscount(Discount discount, Customer customer)
        {
            throw new NotImplementedException();
        }

        public DiscountValidationResult ValidateDiscount(Discount discount, Customer customer, string[] couponCodesToValidate)
        {
            throw new NotImplementedException();
        }

        public DiscountValidationResult ValidateDiscount(DiscountForCaching discount, Customer customer)
        {
            throw new NotImplementedException();
        }

        public DiscountValidationResult ValidateDiscount(DiscountForCaching discount, Customer customer, string[] couponCodesToValidate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

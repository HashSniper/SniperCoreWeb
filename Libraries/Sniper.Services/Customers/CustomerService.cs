using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Domain.Common;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Orders;
using Sniper.Core.Domain.Tax;
using System.Linq;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Data;
using Sniper.Services.Events;
using Sniper.Services.Common;

namespace Sniper.Services.Customers
{
    public partial class CustomerService : ICustomerService
    {
        #region Fields
        private readonly CustomerSettings _customerSettings;
        private readonly ICacheManager _cacheManager;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IEventPublisher _eventPublisher;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<CustomerCustomerRoleMapping> _customerCustomerRoleMappingRepository;
        private readonly IRepository<CustomerPassword> _customerPasswordRepository;
        private readonly IRepository<CustomerRole> _customerRoleRepository;
        private readonly IRepository<GenericAttribute> _gaRepository;
        private readonly IRepository<ShoppingCartItem> _shoppingCartRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ShoppingCartSettings _shoppingCartSettings;
        #endregion

        #region Ctor

        public CustomerService(CustomerSettings customerSettings,
            ICacheManager cacheManager,
            IDataProvider dataProvider,
            IDbContext dbContext,
            IEventPublisher eventPublisher,
            IGenericAttributeService genericAttributeService,
            IRepository<Customer> customerRepository,
            IRepository<CustomerCustomerRoleMapping> customerCustomerRoleMappingRepository,
            IRepository<CustomerPassword> customerPasswordRepository,
            IRepository<CustomerRole> customerRoleRepository,
            IRepository<GenericAttribute> gaRepository,
            IRepository<ShoppingCartItem> shoppingCartRepository,
            IStaticCacheManager staticCacheManager,
            ShoppingCartSettings shoppingCartSettings)
        {
            _customerSettings = customerSettings;
            _cacheManager = cacheManager;
            _dataProvider = dataProvider;
            _dbContext = dbContext;
            _eventPublisher = eventPublisher;
            _genericAttributeService = genericAttributeService;
            _customerRepository = customerRepository;
            _customerCustomerRoleMappingRepository = customerCustomerRoleMappingRepository;
            _customerPasswordRepository = customerPasswordRepository;
            _customerRoleRepository = customerRoleRepository;
            _gaRepository = gaRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _staticCacheManager = staticCacheManager;
            _shoppingCartSettings = shoppingCartSettings;
        }

        #endregion

        #region Methods
        public void ApplyDiscountCouponCode(Customer customer, string couponCode)
        {
            throw new NotImplementedException();
        }

        public void ApplyGiftCardCouponCode(Customer customer, string couponCode)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomerRole(CustomerRole customerRole)
        {
            throw new NotImplementedException();
        }

        public int DeleteGuestCustomers(DateTime? createdFromUtc, DateTime? createdToUtc, bool onlyWithoutShoppingCart)
        {
            throw new NotImplementedException();
        }

        public string FormatUsername(Customer customer, bool stripTooLong = false, int maxLength = 0)
        {
            throw new NotImplementedException();
        }

        public IList<CustomerRole> GetAllCustomerRoles(bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Customer> GetAllCustomers(DateTime? createdFromUtc = null, DateTime? createdToUtc = null, int affiliateId = 0, int vendorId = 0, int[] customerRoleIds = null, string email = null, string username = null, string firstName = null, string lastName = null, int dayOfBirth = 0, int monthOfBirth = 0, string company = null, string phone = null, string zipPostalCode = null, string ipAddress = null, int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false)
        {
            throw new NotImplementedException();
        }

        public CustomerPassword GetCurrentPassword(int customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByGuid(Guid customerGuid)
        {
            if (customerGuid == Guid.Empty)
                return null;

            var query = from c in _customerRepository.Table
                        where c.CustomerGuid == customerGuid
                        orderby c.Id
                        select c;

            var customer = query.FirstOrDefault();
            return customer;
        }

        public Customer GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerBySystemName(string systemName)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public TaxDisplayType? GetCustomerDefaultTaxDisplayType(Customer customer)
        {
            throw new NotImplementedException();
        }

        public string GetCustomerFullName(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IList<CustomerPassword> GetCustomerPasswords(int? customerId = null, PasswordFormat? passwordFormat = null, int? passwordsToReturn = null)
        {
            throw new NotImplementedException();
        }

        public CustomerRole GetCustomerRoleById(int customerRoleId)
        {
            throw new NotImplementedException();
        }

        public virtual CustomerRole GetCustomerRoleBySystemName(string systemName)
        {
            if (string.IsNullOrEmpty(systemName))
                return null;

            var key = string.Format(NopCustomerServiceDefaults.CustomerRolesBySystemNameCacheKey, systemName);

            return _cacheManager.Get(key, () =>
            {
                var query = from cr in _customerRoleRepository.Table
                            orderby cr.Id
                            where cr.SystemName == systemName
                            select cr;
                var customerRole = query.FirstOrDefault();

                return customerRole;
            });
        }

        public IList<Customer> GetCustomersByIds(int[] customerIds)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Customer> GetCustomersWithShoppingCarts(ShoppingCartType? shoppingCartType = null, int storeId = 0, int? productId = null, DateTime? createdFromUtc = null, DateTime? createdToUtc = null, int? countryId = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Customer> GetOnlineCustomers(DateTime lastActivityFromUtc, int[] customerRoleIds, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public void InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void InsertCustomerPassword(CustomerPassword customerPassword)
        {
            throw new NotImplementedException();
        }

        public void InsertCustomerRole(CustomerRole customerRole)
        {
            throw new NotImplementedException();
        }

        public Customer InsertGuestCustomer()
        {
            Customer customer = new Customer
            {
                CustomerGuid = Guid.NewGuid(),
                Active = true,
                CreatedOnUtc = DateTime.UtcNow,
                LastActivityDateUtc = DateTime.UtcNow
            };

            var guestRole = GetCustomerRoleBySystemName(NopCustomerDefaults.GuestsRoleName);

            if(guestRole==null)
                throw new NopException("'Guests' role could not be loaded");
            customer.AddCustomerRoleMapping(new CustomerCustomerRoleMapping { CustomerRole = guestRole });

            _customerRepository.Insert(customer);

            return customer;
        }

        public bool IsPasswordRecoveryLinkExpired(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool IsPasswordRecoveryTokenValid(Customer customer, string token)
        {
            throw new NotImplementedException();
        }

        public string[] ParseAppliedDiscountCouponCodes(Customer customer)
        {
            throw new NotImplementedException();
        }

        public string[] ParseAppliedGiftCardCouponCodes(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool PasswordIsExpired(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomerAddress(Customer customer, Address address)
        {
            throw new NotImplementedException();
        }

        public void RemoveDiscountCouponCode(Customer customer, string couponCode)
        {
            throw new NotImplementedException();
        }

        public void RemoveGiftCardCouponCode(Customer customer, string couponCode)
        {
            throw new NotImplementedException();
        }

        public void ResetCheckoutData(Customer customer, int storeId, bool clearCouponCodes = false, bool clearCheckoutAttributes = false, bool clearRewardPoints = true, bool clearShippingMethod = true, bool clearPaymentMethod = true)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomerPassword(CustomerPassword customerPassword)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomerRole(CustomerRole customerRole)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

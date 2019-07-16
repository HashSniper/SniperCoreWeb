using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Domain.Common;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Orders;
using Sniper.Core.Domain.Tax;

namespace Sniper.Services.Customers
{
    public partial class CustomerService : ICustomerService
    {
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
            throw new NotImplementedException();
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

        public CustomerRole GetCustomerRoleBySystemName(string systemName)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
    }
}

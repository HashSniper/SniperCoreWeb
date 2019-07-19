using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Sniper.Core.Domain.Customers;
using Sniper.Services.Customers;

namespace Sniper.Services.Authentication
{
    public partial class CookieAuthenticationService : IAuthenticationService
    {
        #region Fields
        private readonly CustomerSettings _customerSettings;
        private readonly ICustomerService _customerService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private Customer _cachedCustomer;

        #endregion

        #region Ctor
        public CookieAuthenticationService(CustomerSettings customerSettings,
           ICustomerService customerService,
           IHttpContextAccessor httpContextAccessor)
        {
            _customerSettings = customerSettings;
            _customerService = customerService;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 获得经过身份验证的客户
        /// </summary>
        /// <returns></returns>
        public virtual Customer GetAuthenticatedCustomer()
        {
            if (_cachedCustomer != null)
                return _cachedCustomer;

            var authenticateResult = _httpContextAccessor.HttpContext.AuthenticateAsync(NopAuthenticationDefaults.AuthenticationScheme).Result;

            if (!authenticateResult.Succeeded)
                return null;

            Customer customer = null;

            if (_customerSettings.UsernamesEnabled)
            {
                var usernameClaim = authenticateResult.Principal.FindFirst(p => p.Type == ClaimTypes.Name
                  && p.Issuer.Equals(NopAuthenticationDefaults.ClaimsIssuer, StringComparison.InvariantCultureIgnoreCase));

                if (usernameClaim != null)
                {
                    customer = _customerService.GetCustomerByUsername(usernameClaim.Value);
                }
            }
            else
            {
                var emailClaim = authenticateResult.Principal.FindFirst(p => p.Type == ClaimTypes.Email &&
                  p.Issuer.Equals(NopAuthenticationDefaults.ClaimsIssuer, StringComparison.InvariantCultureIgnoreCase));

                if (emailClaim != null)
                {
                    customer = _customerService.GetCustomerByEmail(emailClaim.Value);
                }
            }

            if (customer == null || !customer.Active || customer.RequireReLogin || customer.Deleted || !customer.IsRegistered())
            {
                return null;
            }

            _cachedCustomer = customer;
            return _cachedCustomer;

        }

        public void SignIn(Customer customer, bool isPersistent)
        {
            throw new NotImplementedException();
        }

        public void SignOut()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Sniper.Core;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Directory;
using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Tax;
using Sniper.Core.Domain.Vendors;
using Sniper.Core.Http;
using Sniper.Services.Authentication;
using Sniper.Services.Common;
using Sniper.Services.Customers;
using Sniper.Services.Directory;
using Sniper.Services.Helpers;
using Sniper.Services.Localization;
using Sniper.Services.Stores;
using Sniper.Services.Tasks;
using Sniper.Services.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniper.Web.Framework
{
    public partial class WebWorkContext : IWorkContext
    {
        #region Fields
        private readonly CurrencySettings _currencySettings;
        private readonly IAuthenticationService _authenticationService;
        private readonly ICurrencyService _currencyService;
        private readonly ICustomerService _customerService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILanguageService _languageService;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IUserAgentHelper _userAgentHelper;
        private readonly IVendorService _vendorService;
        private readonly LocalizationSettings _localizationSettings;
        private readonly TaxSettings _taxSettings;

        private Customer _cachedCustomer;
        private Customer _originalCustomerIfImpersonated;
        private Vendor _cachedVendor;
        private Language _cachedLanguage;
        private Currency _cachedCurrency;
        private TaxDisplayType? _cachedTaxDisplayType;
        #endregion

        #region Ctor
        public WebWorkContext(CurrencySettings currencySettings,
           IAuthenticationService authenticationService,
           ICurrencyService currencyService,
           ICustomerService customerService,
           IGenericAttributeService genericAttributeService,
           IHttpContextAccessor httpContextAccessor,
           ILanguageService languageService,
           IStoreContext storeContext,
           IStoreMappingService storeMappingService,
           IUserAgentHelper userAgentHelper,
           IVendorService vendorService,
           LocalizationSettings localizationSettings,
           TaxSettings taxSettings)
        {
            _currencySettings = currencySettings;
            _authenticationService = authenticationService;
            _currencyService = currencyService;
            _customerService = customerService;
            _genericAttributeService = genericAttributeService;
            _httpContextAccessor = httpContextAccessor;
            _languageService = languageService;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _userAgentHelper = userAgentHelper;
            _vendorService = vendorService;
            _localizationSettings = localizationSettings;
            _taxSettings = taxSettings;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 当前客户
        /// </summary>
        public Customer CurrentCustomer {
            get {
                if (_cachedCustomer != null)
                    return _cachedCustomer;

                Customer customer = null;


                if (_httpContextAccessor.HttpContext == null ||
                    _httpContextAccessor.HttpContext.Request.Path.Equals(new PathString($"/{NopTaskDefaults.ScheduleTaskPath}"), StringComparison.InvariantCultureIgnoreCase))
                {
                    //in this case return built-in customer record for background task
                    customer = _customerService.GetCustomerBySystemName(NopCustomerDefaults.BackgroundTaskCustomerName);
                }
                if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                {
                    if (_userAgentHelper.IsSearchEngine())
                    {
                        customer = _customerService.GetCustomerBySystemName(NopCustomerDefaults.SearchEngineCustomerName);
                    }
                }

                if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                {
                    customer = _authenticationService.GetAuthenticatedCustomer();
                }

                if (customer != null && !customer.Deleted && customer.Active && !customer.RequireReLogin)
                {
                    var impersonatedCustomerId = _genericAttributeService.GetAttribute<int?>(customer, NopCustomerDefaults.ImpersonatedCustomerIdAttribute);

                    if (impersonatedCustomerId.HasValue && impersonatedCustomerId.Value > 0)
                    {
                        var impersonatedCustomer = _customerService.GetCustomerById(impersonatedCustomerId.Value);

                        if (impersonatedCustomer != null && !impersonatedCustomer.Deleted && impersonatedCustomer.Active && !impersonatedCustomer.RequireReLogin)
                        {
                            _originalCustomerIfImpersonated = customer;
                            customer = impersonatedCustomer;
                        }
                    }
                }

                if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                {
                    var customerCookie = GetCustomerCookie();

                    if (!string.IsNullOrEmpty(customerCookie))
                    {
                        if (Guid.TryParse(customerCookie, out Guid customerGuid))
                        {
                            var customerByCookie = _customerService.GetCustomerByGuid(customerGuid);
                            if (customerByCookie != null && !customerByCookie.IsRegistered())
                            {
                                customer = customerByCookie;
                            }
                        }
                    }
                }

                if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                {
                    customer = _customerService.InsertGuestCustomer();
                }

                if (!customer.Deleted && customer.Active && !customer.RequireReLogin)
                {
                    SetCustomerCookie(customer.CustomerGuid);

                    //cache the found customer
                    _cachedCustomer = customer;
                }

                return _cachedCustomer;
            }
            set {
                SetCustomerCookie(value.CustomerGuid);
                _cachedCustomer = value;
            }
        }

        public Customer OriginalCustomerIfImpersonated => throw new NotImplementedException();

        public Vendor CurrentVendor => throw new NotImplementedException();

        public virtual Language WorkingLanguage {
            get
            {
                if (_cachedLanguage != null)
                    return _cachedLanguage;

                Language detectedLanguage = null;
                if (_localizationSettings.SeoFriendlyUrlsForLanguagesEnabled)
                    detectedLanguage = GetLanguageFromUrl();

                if (detectedLanguage == null && _localizationSettings.AutomaticallyDetectLanguage)
                {
                    var alreadyDetected = _genericAttributeService.GetAttribute<bool>(CurrentCustomer, NopCustomerDefaults.LanguageAutomaticallyDetectedAttribute,
                        _storeContext.CurrentStore.Id);

                    if (!alreadyDetected)
                    {
                        detectedLanguage = GetLanguageFromRequest();

                        if (detectedLanguage != null)
                        {
                            _genericAttributeService.SaveAttribute(CurrentCustomer, NopCustomerDefaults.LanguageAutomaticallyDetectedAttribute
                                , true, _storeContext.CurrentStore.Id);
                        }
                    }
                }

                if (detectedLanguage != null)
                {
                    var currentLanguageId = _genericAttributeService.GetAttribute<int>(CurrentCustomer, NopCustomerDefaults.LanguageIdAttribute,
                        _storeContext.CurrentStore.Id);

                    if (detectedLanguage.Id != currentLanguageId)
                    {
                        _genericAttributeService.SaveAttribute(CurrentCustomer, NopCustomerDefaults.LanguageIdAttribute,
                            detectedLanguage.Id, _storeContext.CurrentStore.Id);
                    }
                }

                var customerLanguageId = _genericAttributeService.GetAttribute<int>(CurrentCustomer, NopCustomerDefaults.LanguageIdAttribute, _storeContext.CurrentStore.Id);

                var allStoreLanguages = _languageService.GetAllLanguages(storeId: _storeContext.CurrentStore.Id);

                var customerLanguage = allStoreLanguages.FirstOrDefault(p => p.Id == customerLanguageId);

                if (customerLanguage == null)
                {
                    customerLanguage = allStoreLanguages.FirstOrDefault(p => p.Id == _storeContext.CurrentStore.DefaultLanguageId);
                }

                if (customerLanguage == null)
                {
                    allStoreLanguages.FirstOrDefault();
                }

                if (customerLanguage == null)
                {
                    customerLanguage = _languageService.GetAllLanguages().FirstOrDefault();
                }

                _cachedLanguage = customerLanguage;

                return _cachedLanguage;



            }
            set
            {
                var languageId = value?.Id ?? 0;

                _genericAttributeService.SaveAttribute(CurrentCustomer,
                    NopCustomerDefaults.LanguageIdAttribute, languageId, _storeContext.CurrentStore.Id);

                _cachedCurrency = null;
            }
        }
        public Currency WorkingCurrency { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TaxDisplayType TaxDisplayType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsAdmin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region Utilities

        /// <summary>
        /// 从请求的页面URL获取语言
        /// </summary>
        /// <returns></returns>
        protected virtual Language GetLanguageFromUrl()
        {
            if (_httpContextAccessor.HttpContext?.Request == null)
                return null;
            var path = _httpContextAccessor.HttpContext.Request.Path.Value;

            if (!path.IsLocalizedUrl(_httpContextAccessor.HttpContext.Request.PathBase, false, out Language language))
            {
                return null;
            }

            if (!_storeMappingService.Authorize(language))
                return null;
            return language;
        }

        /// <summary>
        /// 从请求中获取语言
        /// </summary>
        /// <returns></returns>
        public virtual Language GetLanguageFromRequest()
        {
            if (_httpContextAccessor.HttpContext?.Request == null)
            {
                return null;
            }

            var requestCulture = _httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture;

            if (requestCulture == null)
                return null;

            var requestLanguage = _languageService.GetAllLanguages().FirstOrDefault(language =>
              language.LanguageCulture.Equals(requestCulture.Culture.Name, StringComparison.InvariantCultureIgnoreCase)
            );

            if (requestLanguage == null || !requestLanguage.Published || !_storeMappingService.Authorize(requestLanguage))
            {
                return null;
            }

            return requestLanguage;
        }

        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <returns></returns>
        protected virtual string GetCustomerCookie()
        {
            var cookieName = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.CustomerCookie}";

            return _httpContextAccessor.HttpContext?.Request?.Cookies[cookieName];
        }

        /// <summary>
        /// 设置cookies
        /// </summary>
        /// <param name="customerGuid"></param>
        protected virtual void SetCustomerCookie(Guid customerGuid)
        {
            if (_httpContextAccessor.HttpContext?.Request == null)
                return;

            var cookieName = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.CustomerCookie}";

            _httpContextAccessor.HttpContext.Response.Cookies.Delete(cookieName);

            var cookieExpires = 24 * 25;
            var cookieExpiresDate = DateTime.Now.AddHours(cookieExpires);

            if (customerGuid == Guid.Empty)
            {
                cookieExpiresDate = DateTime.Now.AddMonths(-1);
            }

            var options = new CookieOptions
            {
                HttpOnly = true,
                Expires = cookieExpiresDate
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName, customerGuid.ToString(), options);
        }
        #endregion
    }
}

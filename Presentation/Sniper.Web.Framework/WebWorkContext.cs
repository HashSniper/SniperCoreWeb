using Microsoft.AspNetCore.Http;
using Sniper.Core;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Directory;
using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Tax;
using Sniper.Core.Domain.Vendors;
using Sniper.Services.Authentication;
using Sniper.Services.Common;
using Sniper.Services.Customers;
using Sniper.Services.Directory;
using Sniper.Services.Helpers;
using Sniper.Services.Localization;
using Sniper.Services.Stores;
using Sniper.Services.Vendors;
using System;
using System.Collections.Generic;
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
        public Customer CurrentCustomer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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


            } set {

            } }
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

            if(!path.IsLocalizedUrl)
        }

        #endregion
    }
}

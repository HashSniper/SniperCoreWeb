using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Sniper.Core;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Stores;
using Sniper.Core.Infrastructure;
using Sniper.Services.Common;
using Sniper.Services.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniper.Web.Framework
{
    public partial class WebStoreContext : IStoreContext
    {
        #region Fileds
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStoreService _storeService;

        private Store _cachedStore;
        private int? _cachedActiveStoreScopeConfiguration;
        #endregion

        #region Ctor

        public WebStoreContext(IGenericAttributeService genericAttributeService, IHttpContextAccessor httpContextAccessor, IStoreService storeService)
        {
            _genericAttributeService = genericAttributeService;
            _httpContextAccessor = httpContextAccessor;
            _storeService = storeService;
        }

        #endregion

        #region Methods
        public virtual Store CurrentStore
        {
            get
            {
                if (_cachedStore != null)
                    return _cachedStore;

                //try to determine the current store by HOST header
                string host = _httpContextAccessor.HttpContext?.Request?.Headers[HeaderNames.Host];

                var allStores = _storeService.GetAllStores();
                var store = allStores.FirstOrDefault(s => _storeService.ContainsHostValue(s, host));

                if (store == null)
                {
                    //load the first found store
                    store = allStores.FirstOrDefault();
                }

                _cachedStore = store ?? throw new Exception("No store could be loaded");

                return _cachedStore;
            }
        }

        public virtual int ActiveStoreScopeConfiguration
        {
            get {
                if (_cachedActiveStoreScopeConfiguration.HasValue)
                    return _cachedActiveStoreScopeConfiguration.Value;

                if (_storeService.GetAllStores().Count > 1)
                {
                    var currentCustomer = EngineContext.Current.Resolve<IWorkContext>().CurrentCustomer;

                    var storeId = _genericAttributeService.GetAttribute<int>(currentCustomer, NopCustomerDefaults.AdminAreaStoreScopeConfigurationAttribute);

                    _cachedActiveStoreScopeConfiguration = _storeService.GetStoreById(storeId)?.Id ?? 0;
                }
                else
                {
                    _cachedActiveStoreScopeConfiguration = 0;
                }

                return _cachedActiveStoreScopeConfiguration ?? 0;
            }
        }

       
        #endregion


    }
}

using Sniper.Core;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Stores;
using Sniper.Services.Common;
using Sniper.Services.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniper.Web.Framework.Themes
{
    public partial class ThemeContext : IThemeContext
    {
        #region Fieilds
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IStoreContext _storeContext;
        private readonly IThemeProvider _themeProvider;
        private readonly IWorkContext _workContext;
        private readonly StoreInformationSettings _storeInformationSettings;

        private string _cachedThemeName;
        #endregion

        #region Ctor

        public ThemeContext(IGenericAttributeService genericAttributeService,
            IStoreContext storeContext, IThemeProvider themeProvider, IWorkContext workContext, StoreInformationSettings storeInformationSettings)
        {
            _genericAttributeService = genericAttributeService;
            _storeContext = storeContext;
            _themeProvider = themeProvider;
            _workContext = workContext;
            _storeInformationSettings = storeInformationSettings;
        }

        #endregion

        #region Methods
        public string WorkingThemeName {
            get {
                if (!string.IsNullOrEmpty(_cachedThemeName))
                    return _cachedThemeName;

                var themeName = string.Empty;

                if (_storeInformationSettings.AllowCustomerToSelectTheme && _workContext.CurrentCustomer != null)
                {
                    themeName = _genericAttributeService.GetAttribute<string>(_workContext.CurrentCustomer,
                        NopCustomerDefaults.WorkingThemeNameAttribute, _storeContext.CurrentStore.Id);

                }

                if (string.IsNullOrEmpty(themeName))
                {
                    themeName = _storeInformationSettings.DefaultStoreTheme;
                }

                if (!_themeProvider.ThemeExists(themeName))
                {
                    themeName=_themeProvider.GetThemes().FirstOrDefault()?.SystemName?? throw new Exception("No theme could be loaded");
                }

                _cachedThemeName = themeName;

                return _cachedThemeName;
            }
            set {
                if (!_storeInformationSettings.AllowCustomerToSelectTheme || _workContext.CurrentCustomer == null)
                    return;

                _genericAttributeService.SaveAttribute(_workContext.CurrentCustomer, NopCustomerDefaults.WorkingThemeNameAttribute, value, _storeContext.CurrentStore.Id);

                _cachedThemeName = null;
            }
        }
        #endregion

    }
}

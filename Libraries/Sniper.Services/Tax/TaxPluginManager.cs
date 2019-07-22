using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Tax;
using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Tax
{
    public partial class TaxPluginManager : PluginManager<ITaxProvider>, ITaxPluginManager
    {
        #region Fields

        private readonly TaxSettings _taxSettings;

        #endregion

        #region Ctor

        public TaxPluginManager(IPluginService pluginService,
            TaxSettings taxSettings) : base(pluginService)
        {
            _taxSettings = taxSettings;
        }

        #endregion

        #region Methods
        public bool IsPluginActive(ITaxProvider taxProvider)
        {
            throw new NotImplementedException();
        }

        public bool IsPluginActive(string systemName, Customer customer = null, int storeId = 0)
        {
            throw new NotImplementedException();
        }

        public ITaxProvider LoadPrimaryPlugin(Customer customer = null, int storeId = 0)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

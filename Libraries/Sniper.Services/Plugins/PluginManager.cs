using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Domain.Customers;

namespace Sniper.Services.Plugins
{
    public partial class PluginManager<TPlugin> : IPluginManager<TPlugin> where TPlugin : class, IPlugin
    {
        #region Constants

        private const string KEY_FORMAT = "{0}-{1}-{2}";

        #endregion

        #region Fields

        private readonly IPluginService _pluginService;
        private readonly Dictionary<string, IList<TPlugin>> _plugins = new Dictionary<string, IList<TPlugin>>();

        #endregion

        #region Ctor

        public PluginManager(IPluginService pluginService)
        {
            _pluginService = pluginService;
        }

        #endregion

        #region Methods
        public string GetPluginLogoUrl(TPlugin plugin)
        {
            throw new NotImplementedException();
        }

        public bool IsPluginActive(TPlugin plugin, List<string> systemNames)
        {
            throw new NotImplementedException();
        }

        public IList<TPlugin> LoadActivePlugins(List<string> systemNames, Customer customer = null, int storeId = 0)
        {
            throw new NotImplementedException();
        }

        public IList<TPlugin> LoadAllPlugins(Customer customer = null, int storeId = 0)
        {
            throw new NotImplementedException();
        }

        public TPlugin LoadPluginBySystemName(string systemName, Customer customer = null, int storeId = 0)
        {
            throw new NotImplementedException();
        }

        public TPlugin LoadPrimaryPlugin(string systemName, Customer customer = null, int storeId = 0)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

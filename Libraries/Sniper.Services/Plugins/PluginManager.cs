using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// 加载活动插件
        /// </summary>
        /// <param name="systemNames"></param>
        /// <param name="customer"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public virtual IList<TPlugin> LoadActivePlugins(List<string> systemNames, Customer customer = null, int storeId = 0)
        {
            if (systemNames == null)
            {
                return new List<TPlugin>();
            }

            return LoadAllPlugins(customer, storeId)
                .Where(plugin => systemNames.Contains(plugin.PluginDescriptor.SystemName, StringComparer.InvariantCultureIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// 加载所有
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public IList<TPlugin> LoadAllPlugins(Customer customer = null, int storeId = 0)
        {
            var key = string.Format(KEY_FORMAT, null, customer?.CustomerGuid ?? default(Guid), storeId);
            if (!_plugins.ContainsKey(key))
                _plugins.Add(key, _pluginService.GetPlugins<TPlugin>(customer: customer, storeId: storeId).ToList());

            return _plugins[key];
        }

        /// <summary>
        /// 加载所有
        /// </summary>
        /// <param name="systemName"></param>
        /// <param name="customer"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public TPlugin LoadPluginBySystemName(string systemName, Customer customer = null, int storeId = 0)
        {
            return null;
        }

        public TPlugin LoadPrimaryPlugin(string systemName, Customer customer = null, int storeId = 0)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

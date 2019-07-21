using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sniper.Core;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Infrastructure;
using Sniper.Services.Customers;
using Sniper.Services.Localization;
using Sniper.Services.Logging;

namespace Sniper.Services.Plugins
{
    public partial class PluginService : IPluginService
    {
        #region Fields
        private readonly CatalogSettings _catalogSettings;
        private readonly ICustomerService _customerService;
        private readonly ILogger _logger;
        private readonly INopFileProvider _fileProvider;
        private readonly IWebHelper _webHelper;
        private readonly IPluginsInfo _pluginsInfo;

        #endregion

        #region Ctor
        public PluginService(CatalogSettings catalogSettings, ICustomerService customerService, ILogger logger, INopFileProvider fileProvider, IWebHelper webHelper)
        {
            _catalogSettings = catalogSettings;
            _customerService = customerService;
            _logger = logger;
            _fileProvider = fileProvider;
            _webHelper = webHelper;
            _pluginsInfo = Singleton<IPluginsInfo>.Instance; ;
        }
        #endregion

        #region Methods
        public void ClearInstalledPluginsList()
        {
            throw new NotImplementedException();
        }

        public void DeletePlugins()
        {
            throw new NotImplementedException();
        }

        public IPlugin FindPluginByTypeInAssembly(Type typeInAssembly)
        {
            throw new NotImplementedException();
        }

        public IList<PluginLoadedAssemblyInfo> GetAssemblyCollisions()
        {
            throw new NotImplementedException();
        }

        public IList<string> GetIncompatiblePlugins()
        {
            throw new NotImplementedException();
        }

        public string GetPluginLogoUrl(PluginDescriptor pluginDescriptor)
        {
            throw new NotImplementedException();
        }

        public virtual void InstallPlugins()
        {
            var pluginDescriptors = _pluginsInfo.PluginDescriptors.Where(p => !p.Installed).ToList();

            pluginDescriptors = pluginDescriptors.Where(p => _pluginsInfo.PluginNamesToInstall.Any(x => x.SystemName.Equals(p.SystemName))).ToList();

            if (!pluginDescriptors.Any())
            {
                return;
            }

            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            var customerActivityService = EngineContext.Current.Resolve<ICustomerActivityService>();

            foreach (var descriptor in pluginDescriptors.OrderBy(pluginDescriptor => pluginDescriptor.DisplayOrder))
            {
                try
                {
                    descriptor.Instance<IPlugin>().Install();

                    var pluginToInstall = _pluginsInfo.PluginNamesToInstall.FirstOrDefault(plugin => plugin.SystemName.Equals(descriptor.SystemName));

                    _pluginsInfo.InstalledPluginNames.Add(descriptor.SystemName);

                    _pluginsInfo.PluginNamesToInstall.Remove(pluginToInstall);


                    var customer = _customerService.GetCustomerByGuid(pluginToInstall.CustomerGuid ?? Guid.Empty);

                    customerActivityService.InsertActivity(customer, "InstallNewPlugin",
                        string.Format(localizationService.GetResource("ActivityLog.InstallNewPlugin"), descriptor.SystemName));

                    descriptor.Installed = true;
                    descriptor.ShowInPluginsList = true;
                }
                catch (Exception exception)
                {
                    var message = string.Format(localizationService.GetResource("Admin.Plugins.Errors.NotInstalled"), descriptor.SystemName);
                    _logger.Error(message, exception);
                }
            }

            _pluginsInfo.Save();
        }

        public bool IsRestartRequired()
        {
            throw new NotImplementedException();
        }

        public void PreparePluginToDelete(string systemName)
        {
            throw new NotImplementedException();
        }

        public void PreparePluginToInstall(string systemName, Customer customer = null, bool checkDependencies = true)
        {
            throw new NotImplementedException();
        }

        public void PreparePluginToUninstall(string systemName)
        {
            throw new NotImplementedException();
        }

        public void ResetChanges()
        {
            throw new NotImplementedException();
        }

        public void UninstallPlugins()
        {
            throw new NotImplementedException();
        }

        PluginDescriptor IPluginService.GetPluginDescriptorBySystemName<TPlugin>(string systemName, LoadPluginsMode loadMode, Customer customer, int storeId, string group)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<PluginDescriptor> GetPluginDescriptors<TPlugin>(LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly,
            Customer customer = null, int storeId = 0, string group = null, string dependsOnSystemName = "") where TPlugin : class, IPlugin
        {
            var pluginDescriptors = _pluginsInfo.PluginDescriptors;

            pluginDescriptors = pluginDescriptors.Where(descriptor =>
               FilterByLoadMode(descriptor, loadMode) &&
               FilterByCustomer(descriptor, customer) &&
               FilterByStore(descriptor, storeId) &&
               FilterByPluginGroup(descriptor, group) &&
               FilterByDependsOn(descriptor, dependsOnSystemName));

            //filter by the passed type
            if (typeof(TPlugin) != typeof(IPlugin))
                pluginDescriptors = pluginDescriptors.Where(descriptor => typeof(TPlugin).IsAssignableFrom(descriptor.PluginType));

            //order by group name
            pluginDescriptors = pluginDescriptors.OrderBy(descriptor => descriptor.Group)
                .ThenBy(descriptor => descriptor.DisplayOrder).ToList();

            return pluginDescriptors;
        }

        public virtual IEnumerable<TPlugin> GetPlugins<TPlugin>(LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly,
            Customer customer = null, int storeId = 0, string group = null) where TPlugin : class, IPlugin
        {
            return GetPluginDescriptors<TPlugin>(loadMode, customer, storeId, group)
                .Select(descriptor => descriptor.Instance<TPlugin>());
        }



        #endregion

        #region Utilities
        /// <summary>
        /// 是否根据传递的加载模式加载插件
        /// </summary>
        /// <param name="pluginDescriptor"></param>
        /// <param name="loadMode"></param>
        /// <returns></returns>
        protected virtual bool FilterByLoadMode(PluginDescriptor pluginDescriptor, LoadPluginsMode loadMode)
        {
            if(pluginDescriptor==null)
                throw new ArgumentNullException(nameof(pluginDescriptor));

            switch (loadMode)
            {
                case LoadPluginsMode.All:
                    return true;

                case LoadPluginsMode.InstalledOnly:
                    return pluginDescriptor.Installed;

                case LoadPluginsMode.NotInstalledOnly:
                    return !pluginDescriptor.Installed;
                default:
                    throw new NotSupportedException(nameof(loadMode));
            }
        }

        /// <summary>
        /// 检查是否根据传递的客户加载插件
        /// </summary>
        /// <param name="pluginDescriptor"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        protected virtual bool FilterByCustomer(PluginDescriptor pluginDescriptor, Customer customer)
        {
            if (pluginDescriptor == null)
                throw new ArgumentNullException(nameof(pluginDescriptor));

            if (customer == null || !pluginDescriptor.LimitedToCustomerRoles.Any())
                return true;

            if (_catalogSettings.IgnoreAcl)
                return true;

            return pluginDescriptor.LimitedToCustomerRoles.Intersect(customer.GetCustomerRoleIds()).Any();
        }

        /// <summary>
        /// 检查是否根据传递的商店标识加载插件
        /// </summary>
        /// <param name="pluginDescriptor"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        protected virtual bool FilterByStore(PluginDescriptor pluginDescriptor, int storeId)
        {
            if (pluginDescriptor == null)
                throw new ArgumentNullException(nameof(pluginDescriptor));

            if (storeId == 0)
                return true;

            if (!pluginDescriptor.LimitedToStores.Any())
            {
                return true;
            }

            return pluginDescriptor.LimitedToStores.Contains(storeId);
        }

        /// <summary>
        /// 检查是否根据其他插件的依赖性加载插件
        /// </summary>
        /// <param name="pluginDescriptor"></param>
        /// <param name="dependsOnSystemName"></param>
        /// <returns></returns>
        protected virtual bool FilterByDependsOn(PluginDescriptor pluginDescriptor, string dependsOnSystemName)
        {
            if (pluginDescriptor == null)
                throw new ArgumentNullException(nameof(pluginDescriptor));

            if (string.IsNullOrEmpty(dependsOnSystemName))
                return true;

            return pluginDescriptor.DependsOn?.Contains(dependsOnSystemName) ?? true;
        }

        /// <summary>
        /// 检查是否根据传递的插件组加载插件
        /// </summary>
        /// <param name="pluginDescriptor"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        protected virtual bool FilterByPluginGroup(PluginDescriptor pluginDescriptor, string group)
        {
            if (pluginDescriptor == null)
                throw new ArgumentNullException(nameof(pluginDescriptor));

            if (string.IsNullOrEmpty(group))
                return true;

            return group.Equals(pluginDescriptor.Group, StringComparison.InvariantCultureIgnoreCase);
        }
        #endregion
    }
}

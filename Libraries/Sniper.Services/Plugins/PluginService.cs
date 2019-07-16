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

        IEnumerable<PluginDescriptor> IPluginService.GetPluginDescriptors<TPlugin>(LoadPluginsMode loadMode, Customer customer, int storeId, string group, string dependsOnSystemName)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TPlugin> IPluginService.GetPlugins<TPlugin>(LoadPluginsMode loadMode, Customer customer, int storeId, string group)
        {
            throw new NotImplementedException();
        }
    }
}

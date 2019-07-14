using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Domain.Customers;

namespace Sniper.Services.Plugins
{
    public partial class PluginService : IPluginService
    {
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

        public void InstallPlugins()
        {
            throw new NotImplementedException();
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

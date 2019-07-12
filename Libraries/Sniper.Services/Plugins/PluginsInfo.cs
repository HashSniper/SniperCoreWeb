using Newtonsoft.Json;
using Sniper.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sniper.Services.Plugins
{
    public partial class PluginsInfo:IPluginsInfo
    {
        protected readonly INopFileProvider _fileProvider;

        #region Ctor
        public PluginsInfo(INopFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the list of all installed plugin names
        /// </summary>
        public virtual IList<string> InstalledPluginNames { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the list of plugin names which will be uninstalled
        /// </summary>
        public virtual IList<string> PluginNamesToUninstall { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the list of plugin names which will be deleted
        /// </summary>
        public virtual IList<string> PluginNamesToDelete { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the list of plugin names which will be installed
        /// </summary>
        public virtual IList<(string SystemName, Guid? CustomerGuid)> PluginNamesToInstall { get; set; } = new List<(string SystemName, Guid? CustomerGuid)>();

        /// <summary>
        /// Gets or sets the list of plugin names which are not compatible with the current version
        /// </summary>
        [JsonIgnore]
        public virtual IList<string> IncompatiblePlugins { get; set; }

        /// <summary>
        /// Gets or sets the list of assembly loaded collisions
        /// </summary>
        [JsonIgnore]
        public virtual IList<PluginLoadedAssemblyInfo> AssemblyLoadedCollision { get; set; }

        /// <summary>
        /// Gets or sets a collection of plugin descriptors of all deployed plugins
        /// </summary>
        [JsonIgnore]
        public virtual IEnumerable<PluginDescriptor> PluginDescriptors { get; set; }

        #endregion

        #region Methods        

        public virtual void CopyFrom(IPluginsInfo pluginsInfo)
        {
            InstalledPluginNames = pluginsInfo.InstalledPluginNames?.ToList() ?? new List<string>();
            PluginNamesToUninstall = pluginsInfo.PluginNamesToUninstall?.ToList() ?? new List<string>();
            PluginNamesToDelete = pluginsInfo.PluginNamesToDelete?.ToList() ?? new List<string>();
            PluginNamesToInstall = pluginsInfo.PluginNamesToInstall?.ToList() ?? new List<(string SystemName, Guid? CustomerGuid)>();
            AssemblyLoadedCollision = pluginsInfo.AssemblyLoadedCollision?.ToList();
            PluginDescriptors = pluginsInfo.PluginDescriptors?.ToList();
            IncompatiblePlugins = pluginsInfo.IncompatiblePlugins?.ToList();
        }

        /// <summary>
        /// 加载插件信息
        /// </summary>
        /// <returns></returns>
        public virtual bool LoadPluginInfo()
        {
            var filePath = _fileProvider.MapPath(SniperPluginDefaults.PluginsInfoFilePath);

            if (!_fileProvider.FileExists(filePath))
            {
                InstalledPluginNames = GetObsoleteInstalledPluginNames();

                if (InstalledPluginNames.Any())
                    Save();
            }

            var text = _fileProvider.FileExists(filePath) ? _fileProvider.ReadAllText(filePath, Encoding.UTF8) : string.Empty;

            return !string.IsNullOrEmpty(text) && DeserializePluginInfo(text);
        }

        /// <summary>
        /// 将插件信息转化为json存储
        /// </summary>
        public virtual void Save()
        {
            var filePath = _fileProvider.MapPath(SniperPluginDefaults.PluginsInfoFilePath);
            var text = JsonConvert.SerializeObject(this, Formatting.Indented);
            _fileProvider.WriteAllText(filePath, text, Encoding.UTF8);
        }
        #endregion


        #region Utilities
        protected virtual IList<string> GetObsoleteInstalledPluginNames()
        {
            var filePath = _fileProvider.MapPath(SniperPluginDefaults.InstalledPluginsFilePath);

            if (!_fileProvider.FileExists(filePath))
            {
                filePath = _fileProvider.MapPath(SniperPluginDefaults.ObsoleteInstalledPluginsFilePath);

                if (_fileProvider.FileExists(filePath))
                {
                    return new List<string>();
                }

                var pluginSystemNames = new List<string>();

                using (var reader = new StringReader(_fileProvider.ReadAllText(filePath, Encoding.UTF8)))
                {
                    string pluginName;
                    while ((pluginName = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(pluginName))
                        {
                            pluginSystemNames.Add(pluginName.Trim());
                        }
                    }
                }

                _fileProvider.DeleteFile(filePath);

                return pluginSystemNames;
            }

            var text = _fileProvider.ReadAllText(filePath, Encoding.UTF8);

            return JsonConvert.DeserializeObject<IList<string>>(text);
        }

        /// <summary>
        /// 从json中解析插件信息
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        protected virtual bool DeserializePluginInfo(string json)
        {
            var pluginsInfo = JsonConvert.DeserializeObject<PluginsInfo>(json);

            InstalledPluginNames = pluginsInfo.InstalledPluginNames;

            PluginNamesToUninstall = pluginsInfo.PluginNamesToUninstall;

            PluginNamesToDelete = pluginsInfo.PluginNamesToDelete;

            PluginNamesToInstall = pluginsInfo.PluginNamesToInstall;

            return InstalledPluginNames.Any() || PluginNamesToInstall.Any() || PluginNamesToDelete.Any() || PluginNamesToUninstall.Any();
        }
        #endregion
    }
}

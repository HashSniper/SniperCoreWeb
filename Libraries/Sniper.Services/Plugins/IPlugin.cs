using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Plugins
{
    public interface IPlugin
    {
        /// <summary>
        /// 获取配置页url
        /// </summary>
        /// <returns></returns>
        string GetConfigurationPageUrl();


        PluginDescriptor PluginDescriptor { get; set; }


        void Install();


        void Uninstall();

        void PreparePluginToUninstall();
    }
}

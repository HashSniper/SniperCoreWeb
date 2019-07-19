using Sniper.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Plugins
{
    public partial interface IPluginManager<TPlugin> where TPlugin : class, IPlugin
    {
        /// <summary>
        /// 记载所有插件
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        IList<TPlugin> LoadAllPlugins(Customer customer = null, int storeId = 0);

        /// <summary>
        /// 通过名称加载
        /// </summary>
        /// <param name="systemName"></param>
        /// <param name="customer"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        TPlugin LoadPluginBySystemName(string systemName, Customer customer = null, int storeId = 0);

        /// <summary>
        /// 加载主要活动插件
        /// </summary>
        /// <param name="systemName"></param>
        /// <param name="customer"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        TPlugin LoadPrimaryPlugin(string systemName, Customer customer = null, int storeId = 0);

        /// <summary>
        /// 加载活动插件
        /// </summary>
        /// <param name="systemNames"></param>
        /// <param name="customer"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        IList<TPlugin> LoadActivePlugins(List<string> systemNames, Customer customer = null, int storeId = 0);

        /// <summary>
        /// 检测插件是否处于活动状态
        /// </summary>
        /// <param name="plugin"></param>
        /// <param name="systemNames"></param>
        /// <returns></returns>
        bool IsPluginActive(TPlugin plugin, List<string> systemNames);

        /// <summary>
        /// 获取插件徽标网址
        /// </summary>
        /// <param name="plugin"></param>
        /// <returns></returns>
        string GetPluginLogoUrl(TPlugin plugin);


    }
}

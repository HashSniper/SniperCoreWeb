using Sniper.Core.Domain.Customers;
using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Cms
{
    public partial interface IWidgetPluginManager : IPluginManager<IWidgetPlugin>
    {
        /// <summary>
        ///获取活跃的插件
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="storeId"></param>
        /// <param name="widgetZone"></param>
        /// <returns></returns>
        IList<IWidgetPlugin> LoadActivePlugins(Customer customer = null, int storeId = 0, string widgetZone = null);

        /// <summary>
        /// 传递的小部件是否处于活动状态
        /// </summary>
        /// <param name="widget"></param>
        /// <returns></returns>
        bool IsPluginActive(IWidgetPlugin widget);

        /// <summary>
        /// 具有传递的系统名称的窗口小部件是否处于活动状
        /// </summary>
        /// <param name="systemName"></param>
        /// <param name="customer"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        bool IsPluginActive(string systemName, Customer customer = null, int storeId = 0);

    }
}

using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Cms
{
    public partial interface IWidgetPlugin : IPlugin
    {
        /// <summary>
        /// 是否在管理区域的小部件列表页面上隐藏此插件
        /// </summary>
        bool HideInWidgetList { get; }

        /// <summary>
        /// 应呈现此窗口小部件的窗口小部件区域
        /// </summary>
        /// <returns></returns>
        IList<string> GetWidgetZones();

        /// <summary>
        /// 用于显示窗口小部件的视图组件的名称
        /// </summary>
        /// <param name="widgetZone"></param>
        /// <returns></returns>
        string GetWidgetViewComponentName(string widgetZone);

    }
}

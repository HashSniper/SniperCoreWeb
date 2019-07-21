using Sniper.Core.Domain.Cms;
using Sniper.Core.Domain.Customers;
using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniper.Services.Cms
{
    public partial class WidgetPluginManager : PluginManager<IWidgetPlugin>, IWidgetPluginManager
    {
        #region Fields

        private readonly WidgetSettings _widgetSettings;

        #endregion

        #region Ctor

        public WidgetPluginManager(WidgetSettings widgetSettings,
            IPluginService pluginService) : base(pluginService)
        {
            _widgetSettings = widgetSettings;
        }

        #endregion

        #region Methods
        public bool IsPluginActive(IWidgetPlugin widget)
        {
            throw new NotImplementedException();
        }

        public bool IsPluginActive(string systemName, Customer customer = null, int storeId = 0)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 加载活动小部件
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="storeId"></param>
        /// <param name="widgetZone"></param>
        /// <returns></returns>
        public IList<IWidgetPlugin> LoadActivePlugins(Customer customer = null, int storeId = 0, string widgetZone = null)
        {
            var widgets = LoadActivePlugins(_widgetSettings.ActiveWidgetSystemNames, customer, storeId);

            if (!string.IsNullOrEmpty(widgetZone))
            {
                widgets = widgets.Where(widget =>
                    widget.GetWidgetZones().Contains(widgetZone, StringComparer.InvariantCultureIgnoreCase)).ToList();
            }

            return widgets;
        }
        #endregion
    }
}

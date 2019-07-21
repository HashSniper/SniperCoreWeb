using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Services.Cms;
using Sniper.Web.Framework.Themes;
using Sniper.Web.Infrastructure.Cache;
using Sniper.Web.Models.Cms;

namespace Sniper.Web.Factories
{
    public partial class WidgetModelFactory : IWidgetModelFactory
    {
        #region Fields

        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IThemeContext _themeContext;
        private readonly IWidgetPluginManager _widgetPluginManager;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public WidgetModelFactory(IStaticCacheManager cacheManager,
            IStoreContext storeContext,
            IThemeContext themeContext,
            IWidgetPluginManager widgetPluginManager,
            IWorkContext workContext)
        {
            _cacheManager = cacheManager;
            _storeContext = storeContext;
            _themeContext = themeContext;
            _widgetPluginManager = widgetPluginManager;
            _workContext = workContext;
        }

        #endregion


        #region Methods
        /// <summary>
        /// 获取渲染小部件模型
        /// </summary>
        /// <param name="widgetZone"></param>
        /// <param name="additionalData"></param>
        /// <returns></returns>
        public List<RenderWidgetModel> PrepareRenderWidgetModel(string widgetZone, object additionalData = null)
        {
            var cacheKey = string.Format(NopModelCacheDefaults.WidgetModelKey,
                 _workContext.CurrentCustomer.Id, _storeContext.CurrentStore.Id, widgetZone, _themeContext.WorkingThemeName);

            var cachedModels=_cacheManager.Get(cacheKey,()=>            
                _widgetPluginManager.LoadActivePlugins(_workContext.CurrentCustomer, _storeContext.CurrentStore.Id, widgetZone)
              .Select(widget => new RenderWidgetModel
              {
                  WidgetViewComponentName = widget.GetWidgetViewComponentName(widgetZone),
                  WidgetViewComponentArguments = new RouteValueDictionary { ["widgetZone"] = widgetZone }
              }));

            var models = cachedModels.Select(renderModel => new RenderWidgetModel
            {
                WidgetViewComponentName = renderModel.WidgetViewComponentName,
                WidgetViewComponentArguments = new RouteValueDictionary { ["widgetZone"] = widgetZone, ["additionalData"] = additionalData }
            }).ToList();

            return models;


        }
        #endregion
    }
}

using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Discounts
{
    public partial class DiscountPluginManager : PluginManager<IDiscountRequirementRule>, IDiscountPluginManager
    {
        #region Ctor

        public DiscountPluginManager(IPluginService pluginService) : base(pluginService)
        {
        }

        #endregion
    }
}

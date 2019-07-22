using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Discounts
{
    public partial interface IDiscountPluginManager : IPluginManager<IDiscountRequirementRule>
    {
    }
}

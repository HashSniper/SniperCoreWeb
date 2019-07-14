using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Configuration
{
    public static partial class NopConfigurationDefaults
    {
        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static string SettingsAllCacheKey => "Nop.setting.all";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string SettingsPrefixCacheKey => "Nop.setting.";
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Plugins
{
    /// <summary>
    ///插件默认配置
    /// </summary>
    public static partial class SniperPluginDefaults
    {
        public static string ObsoleteInstalledPluginsFilePath => "~/App_Data/InstalledPlugins.txt";


        public static string InstalledPluginsFilePath => "~/App_Data/installedPlugins.json";

        public static string PluginsInfoFilePath => "~/App_Data/plugins.json";


        public static string Path => "~/Plugins";

        public static string PathName => "Plugins";

        public static string ShadowCopyPath => "~/Plugins/bin";

        public static string RefsPathName => "refs";

        public static string DescriptionFileName => "plugin.json";

        public static string LogoFileName => "logo";

        public static string ReserveShadowCopyPathName => "reserve_bin_";

        public static string ReserveShadowCopyPathNamePattern => "reserve_bin_*";

        public static List<string> SupportedLogoImageExtensions => new List<string> { "jpg", "png", "gif" };

        public static string UploadsTempPath => "~/App_Data/TempUploads";

        public static string UploadedItemsFileName => "uploadedItems.json";

        public static string ThemesPath => "~/Themes";

        public static string ThemeDescriptionFileName => "theme.json";

        public static string AdminNavigationPluginsCacheKey => "Sniper.plugins.adminnavigation-{0}";

        public static string AdminNavigationPluginsPrefixCacheKey=> "Sniper.plugins.adminnavigation";

    }
}

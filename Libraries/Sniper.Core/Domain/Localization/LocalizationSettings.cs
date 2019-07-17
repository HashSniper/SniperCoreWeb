using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Localization
{
    public class LocalizationSettings : ISettings
    {
        /// <summary>
        /// 默认语言id
        /// </summary>
        public int DefaultAdminLanguageId { get; set; }

        /// <summary>
        /// 使用图像进行语言选择
        /// </summary>
        public bool UseImagesForLanguageSelection { get; set; }

        /// <summary>
        /// 是否启用了具有多种语言的SEO友好URL
        /// </summary>
        public bool SeoFriendlyUrlsForLanguagesEnabled { get; set; }

        /// <summary>
        /// 我们是否应该通过客户区域检测当前语言（浏览器设置）
        /// </summary>
        public bool AutomaticallyDetectLanguage { get; set; }

        /// <summary>
        /// 是否在应用程序启动时加载所有LocaleStringResource记录
        /// </summary>
        public bool LoadAllLocaleRecordsOnStartup { get; set; }

        /// <summary>
        /// 是否在应用程序启动时加载所有LocalizedProperty记录
        /// </summary>
        public bool LoadAllLocalizedPropertiesOnStartup { get; set; }

        /// <summary>
        /// 是否在应用程序启动时加载所有搜索引擎友好名称（slugs）
        /// </summary>
        public bool LoadAllUrlRecordsOnStartup { get; set; }

        /// <summary>
        /// 我们是否应该忽略管理区域的RTL语言属性。
        /// </summary>
        public bool IgnoreRtlPropertyForAdminArea { get; set; }

    }
}

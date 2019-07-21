using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Seo
{
    public class SeoSettings : ISettings
    {
        /// <summary>
        /// 页面标题分隔符
        /// </summary>
        public string PageTitleSeparator { get; set; }

        /// <summary>
        /// 页面标题SEO调整
        /// </summary>
        public PageTitleSeoAdjustment PageTitleSeoAdjustment { get; set; }

        /// <summary>
        /// 默认title
        /// </summary>
        public string DefaultTitle { get; set; }

        /// <summary>
        /// 默认关键字
        /// </summary>
        public string DefaultMetaKeywords { get; set; }

        /// <summary>
        /// 默认描述
        /// </summary>
        public string DefaultMetaDescription { get; set; }

        /// <summary>
        /// 是否将自动生成产品META描述（如果未输入）
        /// </summary>
        public bool GenerateProductMetaDescription { get; set; }

        /// <summary>
        /// 我们是否应该将非西方的角色转换为西方的角色
        /// </summary>
        public bool ConvertNonWesternChars { get; set; }

        /// <summary>
        /// 是否允许使用unicode字符
        /// </summary>
        public bool AllowUnicodeCharsInUrls { get; set; }

        /// <summary>
        /// 是否应使用规范URL标记
        /// </summary>
        public bool CanonicalUrlsEnabled { get; set; }

        /// <summary>
        /// 是否使用带有查询字符串参数的规范URL
        /// </summary>
        public bool QueryStringInCanonicalUrlsEnabled { get; set; }

        /// <summary>
        /// WWW要求（有或没有WWW）
        /// </summary>
        public WwwRequirement WwwRequirement { get; set; }

        /// <summary>
        /// 是否应生成Twitter META标签
        /// </summary>
        public bool TwitterMetaTags { get; set; }

        /// <summary>
        /// 是否应生成Open Graph META标记
        /// </summary>
        public bool OpenGraphMetaTags { get; set; }

        /// <summary>
        /// Slugs（sename）保留了其他一些需求
        /// </summary>
        public List<string> ReservedUrlRecordSlugs { get; set; }

        /// <summary>
        /// <！[CDATA [<head> </ head>]]>部分中的自定义标签
        /// </summary>
        public string CustomHeadTags { get; set; }

    }
}

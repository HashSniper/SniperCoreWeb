using Sniper.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Localization
{
    public partial class Language:BaseEntity, IStoreMappingSupported
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Culture
        /// </summary>
        public string LanguageCulture { get; set; }

        /// <summary>
        /// unique seo code
        /// </summary>
        public string UniqueSeoCode { get; set; }

        /// <summary>
        /// 图像文件名
        /// </summary>
        public string FlagImageFileName { get; set; }

        /// <summary>
        /// 是否支持从右到左
        /// </summary>
        public bool Rtl { get; set; }

        /// <summary>
        /// 是否限制存储区域
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// 语言的默认标志符，默认值为0
        /// </summary>
        public int DefaultCurrencyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 展示顺序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}

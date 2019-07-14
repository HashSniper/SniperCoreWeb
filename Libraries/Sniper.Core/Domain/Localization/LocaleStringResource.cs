using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Localization
{
    public partial class LocaleStringResource:BaseEntity
    {
        /// <summary>
        /// 语言id
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// 资源名称
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// 资源值
        /// </summary>
        public string ResourceValue { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public virtual Language Language { get; set; }
    }
}

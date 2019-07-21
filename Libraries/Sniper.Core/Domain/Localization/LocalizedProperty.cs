using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Localization
{
    public partial class LocalizedProperty : BaseEntity
    {
        /// <summary>
        /// 实体标识符
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// 语言标识符
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// 区域设置密钥组
        /// </summary>
        public string LocaleKeyGroup { get; set; }

        /// <summary>
        /// 区域设置键
        /// </summary>
        public string LocaleKey { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string LocaleValue { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public virtual Language Language { get; set; }

    }
}

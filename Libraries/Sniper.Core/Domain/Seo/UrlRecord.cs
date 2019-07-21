using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Seo
{
    public partial class UrlRecord : BaseEntity
    {
        /// <summary>
        /// 实体标识符
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// 实体名称
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Slug
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// 记录是否有效
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 语言标识符
        /// </summary>
        public int LanguageId { get; set; }


    }
}

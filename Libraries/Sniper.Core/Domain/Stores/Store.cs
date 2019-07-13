using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Stores
{
    public partial class Store:BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 是否启用ssl
        /// </summary>
        public bool SslEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Hosts { get; set; }

        /// <summary>
        /// 默认语言
        /// </summary>
        public int DefaultLanguageId { get; set; }

        /// <summary>
        /// 展示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        ///公司地址
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 公司电话
        /// </summary>
        public string CompanyPhoneNumber { get; set; }

        /// <summary>
        /// 公司增值税
        /// </summary>
        public string CompanyVat { get; set; }
    }
}

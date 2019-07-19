using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Customers
{
    public partial class ExternalAuthenticationRecord : BaseEntity
    {
        /// <summary>
        /// 客户标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 外部标识符
        /// </summary>
        public string ExternalIdentifier { get; set; }

        /// <summary>
        /// 外部显示标识符
        /// </summary>
        public string ExternalDisplayIdentifier { get; set; }

        /// <summary>
        /// OAuthToken
        /// </summary>
        public string OAuthToken { get; set; }

        /// <summary>
        /// OAuthAccessToken
        /// </summary>
        public string OAuthAccessToken { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string ProviderSystemName { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }

    }
}

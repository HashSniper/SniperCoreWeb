using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Security
{
    public class SecuritySettings: ISettings
    {
        /// <summary>
        /// 是否强制使用ssl
        /// </summary>
        public bool ForceSslForAllPages { get; set; }

        /// <summary>
        /// 加密密钥
        /// </summary>
        public string EncryptionKey { get; set; }

        /// <summary>
        /// 管理区域允许的ip列表
        /// </summary>
        public List<string> AdminAreaAllowedIpAddresses { get; set; }

        /// <summary>
        /// 是否应启用管理区域的XSRF保护
        /// </summary>
        public bool EnableXsrfProtectionForAdminArea { get; set; }

        /// <summary>
        /// 是否应启用公用存储的XSRF保护
        /// </summary>
        public bool EnableXsrfProtectionForPublicStore { get; set; }

        /// <summary>
        /// 是否在注册页面启用蜜罐
        /// </summary>
        public bool HoneypotEnabled { get; set; }

        /// <summary>
        /// 蜜罐输入名
        /// </summary>
        public string HoneypotInputName { get; set; }

        /// <summary>
        /// 插件目录黑名单
        /// </summary>
        public string PluginStaticFileExtensionsBlacklist { get; set; }

        /// <summary>
        /// 是否允许在头中使用非ASCII字符
        /// </summary>
        public bool AllowNonAsciiCharactersInHeaders { get; set; }
    }
}

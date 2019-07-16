using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Security
{
    public partial class ProxySettings : ISettings
    {
        /// <summary>
        /// 是否使用代理连接
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 代理地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 代理端口
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// 代理用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 代理密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 是否绕过本地地址
        /// </summary>
        public bool BypassOnLocal { get; set; }

        /// <summary>
        /// 处理程序是否随请求发送授权头
        /// </summary>
        public bool PreAuthenticate { get; set; }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Sniper.Core.Domain.Security;
using Sniper.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Sniper.Web.Framework.Infrastructure.Extensions
{
    public static class HttpClientBuilderExtensions
    {
        /// <summary>
        /// 配置http连接代理
        /// </summary>
        /// <param name="httpClientBuilder"></param>
        public static void WithProxy(this IHttpClientBuilder httpClientBuilder)
        {
            httpClientBuilder.ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handle = new HttpClientHandler();

                var proxySettings = EngineContext.Current.Resolve<ProxySettings>();

                if (!proxySettings.Enabled)
                {
                    return handle;
                }

                var webProxy = new WebProxy($"{proxySettings.Address}:{proxySettings.Port}", proxySettings.BypassOnLocal);

                if (!string.IsNullOrEmpty(proxySettings.Username) && !string.IsNullOrEmpty(proxySettings.Password))
                {
                    webProxy.UseDefaultCredentials = false;
                    webProxy.Credentials = new NetworkCredential
                    {
                        UserName = proxySettings.Username,
                        Password = proxySettings.Password
                    };
                }
                else
                {
                    webProxy.UseDefaultCredentials = true;
                    webProxy.Credentials = CredentialCache.DefaultCredentials;
                }

                handle.UseDefaultCredentials = webProxy.UseDefaultCredentials;
                handle.Proxy = webProxy;
                handle.PreAuthenticate = proxySettings.PreAuthenticate;

                return handle;

            });
        }

    }
}

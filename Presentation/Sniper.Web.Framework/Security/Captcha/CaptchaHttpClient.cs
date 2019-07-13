using Microsoft.Net.Http.Headers;
using Sniper.Core;
using Sniper.Core.Domain.Security;
using Sniper.Services.Security;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Sniper.Web.Framework.Security.Captcha
{
    public partial class CaptchaHttpClient
    {
        #region Fileds
        private readonly CaptchaSettings _captchaSettings;
        private readonly HttpClient _httpClient;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor
        public CaptchaHttpClient(CaptchaSettings captchaSettings, HttpClient httpClient, IWebHelper webHelper)
        {
            httpClient.BaseAddress = new Uri(NopSecurityDefaults.RecaptchaApiUrl);
            httpClient.Timeout = TimeSpan.FromMilliseconds(5000);
            httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, $"nopCommerce-{NopVersion.CurrentVersion}");

            _captchaSettings = captchaSettings;
            _httpClient = httpClient;
            _webHelper = webHelper;
        }
        #endregion

    }
}

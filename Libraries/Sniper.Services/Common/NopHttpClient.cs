using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Sniper.Core;
using Sniper.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Sniper.Services.Common
{
    public partial class NopHttpClient
    {
        #region Fileds
        private readonly AdminAreaSettings _adminAreaSettings;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStoreContext _storeContext;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor
        public NopHttpClient(AdminAreaSettings adminAreaSettings, HttpClient client, IHttpContextAccessor contextAccessor, IStoreContext store, IWebHelper webHelper)
        {
            client.BaseAddress = new Uri("https://www.nopcommerce.com/");
            client.Timeout = TimeSpan.FromMilliseconds(5000);
            client.DefaultRequestHeaders.Add(HeaderNames.UserAgent,$"nopCommerce-{ NopVersion.CurrentVersion}");

            _adminAreaSettings = adminAreaSettings;
            _httpClient = client;
            _httpContextAccessor = contextAccessor;
            _storeContext = store;
            _webHelper = webHelper;
        }
        #endregion
    }
}

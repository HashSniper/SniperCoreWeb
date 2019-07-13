using Sniper.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Sniper.Services.Common
{
    public partial class StoreHttpClient
    {
        #region  Fileds
        private readonly HttpClient _httpClient;

        #endregion

        #region
        public StoreHttpClient(HttpClient client, IWebHelper webHelper)
        {
            client.BaseAddress = new Uri(webHelper.GetStoreLocation());
            _httpClient = client;
        }
        #endregion

    }
}

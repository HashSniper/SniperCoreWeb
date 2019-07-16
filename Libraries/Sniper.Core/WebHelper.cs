using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Sniper.Core.Configuration;
using Sniper.Core.Data;
using Sniper.Core.Http;
using Sniper.Core.Infrastructure;

namespace Sniper.Core
{
    public partial class WebHelper : IWebHelper
    {
        #region Fileds
        private readonly HostingConfig _hostingConfig;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IApplicationLifetime _applicationLifetime;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly INopFileProvider _fileProvider;
        private readonly IUrlHelperFactory _urlHelperFactory;
        #endregion

        #region Ctor
        public WebHelper(HostingConfig hostingConfig, IActionContextAccessor actionContextAccessor,
            IApplicationLifetime applicationLifetime, IHttpContextAccessor httpContextAccessor,
            INopFileProvider fileProvider, IUrlHelperFactory urlHelperFactory)
        {
            _hostingConfig = hostingConfig;
            _actionContextAccessor = actionContextAccessor;
            _applicationLifetime = applicationLifetime;
            _httpContextAccessor = httpContextAccessor;
            _fileProvider = fileProvider;
            _urlHelperFactory = urlHelperFactory;
        }
        #endregion

        #region Methods

        public bool IsRequestBeingRedirected => throw new NotImplementedException();

        public bool IsPostBeingDone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string CurrentRequestProtocol => throw new NotImplementedException();

        /// <summary>
        /// 从HTTP上下文获取IP地址
        /// </summary>
        /// <returns></returns>
        public  virtual string GetCurrentIpAddress()
        {
            if (!IsRequestAvailable())
            {
                return string.Empty;
            }

            var result = string.Empty;
            try
            {
                if (_httpContextAccessor.HttpContext.Request.Headers != null)
                {
                    var forwardedHttpHeaderKey = NopHttpDefaults.XForwardedForHeader;

                    if (!string.IsNullOrEmpty(_hostingConfig.ForwardedHttpHeader))
                    {
                        forwardedHttpHeaderKey = _hostingConfig.ForwardedHttpHeader;
                    }

                    var forwardedHeader = _httpContextAccessor.HttpContext.Request.Headers[forwardedHttpHeaderKey];

                    if (!StringValues.IsNullOrEmpty(forwardedHeader))
                        result = forwardedHeader.FirstOrDefault();
                }

                if (string.IsNullOrEmpty(result) && _httpContextAccessor.HttpContext.Connection.RemoteIpAddress != null)
                    result = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            catch
            {
                return string.Empty;
            }

            if (result != null && result.Equals(IPAddress.IPv6Loopback.ToString(), StringComparison.InvariantCultureIgnoreCase))
                result = IPAddress.Loopback.ToString();

            if (IPAddress.TryParse(result ?? string.Empty, out var ip))
            {
                result = ip.ToString();
            }
            else if (!string.IsNullOrEmpty(result))
            {
                result = result.Split(':').FirstOrDefault();
            }

            return result;
        }

        public string GetRawUrl(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取商店主机位置
        /// </summary>
        /// <param name="useSsl"></param>
        /// <returns></returns>
        public virtual string GetStoreHost(bool useSsl)
        {
            if (!IsRequestAvailable())
                return string.Empty;

            var hostHeader = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Host];
            if (StringValues.IsNullOrEmpty(hostHeader))
            {
                return string.Empty;
            }

            var storeHost = $"{(useSsl ? Uri.UriSchemeHttps : Uri.UriSchemeHttp)}{Uri.SchemeDelimiter}{hostHeader.FirstOrDefault()}";

            storeHost = $"{storeHost.TrimEnd('/')}/";
            return storeHost;
        }

        /// <summary>
        ///获取位置
        /// </summary>
        /// <param name="userUrl"></param>
        /// <returns></returns>
        public virtual string GetStoreLocation(bool? useSsl = null)
        {
            string storeLocation = string.Empty;

            var storeHost = GetStoreHost(useSsl ?? IsCurrentConnectionSecured());

            if (!string.IsNullOrEmpty(storeHost))
            {
                storeLocation = IsRequestAvailable() ? $"{storeHost.TrimEnd('/')}{_httpContextAccessor.HttpContext.Request}" : storeHost;
            }

            if (string.IsNullOrEmpty(storeHost) && DataSettingsManager.DatabaseIsInstalled)
            {
                storeLocation= EngineContext.Current.Resolve<IStoreContext>().CurrentStore?.Url
                                        ?? throw new Exception("Current store cannot be loaded");
            }

            storeLocation = $"{storeLocation.TrimEnd('/')}/";
            return storeLocation;
        }

        /// <summary>
        /// get page url
        /// </summary>
        /// <param name="includeQueryString"></param>
        /// <param name="useSsl"></param>
        /// <param name="lowercaseUrl"></param>
        /// <returns></returns>
        public virtual string GetThisPageUrl(bool includeQueryString, bool? useSsl = false, bool lowercaseUrl = false)
        {
            if (!IsRequestAvailable())
                return string.Empty;

            var storeLocation = GetStoreLocation(useSsl ?? IsCurrentConnectionSecured());

            var pageUrl = $"{storeLocation.TrimEnd('/')}{_httpContextAccessor.HttpContext.Request.Path}";

            if (includeQueryString)
            {
                pageUrl = $"{pageUrl}{_httpContextAccessor.HttpContext.Request.QueryString}";
            }

            if (lowercaseUrl)
            {
                pageUrl = pageUrl.ToLowerInvariant();
            }

            return pageUrl;
        }

        /// <summary>
        /// 获取URL来源（如果存在）
        /// </summary>
        /// <returns></returns>
        public  virtual string GetUrlReferrer()
        {

            if (!IsRequestAvailable())
                return string.Empty;

            return _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Referer];           
        }

        public bool IsAjaxRequest(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 当前列链接是否安全
        /// </summary>
        /// <returns></returns>
        public bool IsCurrentConnectionSecured()
        {
            if (!IsRequestAvailable())
                return false;

            if (_hostingConfig.UseHttpClusterHttps)
            {
                return _httpContextAccessor.HttpContext.Request.Headers[NopHttpDefaults.HttpClusterHttpsHeader].ToString().Equals("on", StringComparison.OrdinalIgnoreCase);
            }

            if (_hostingConfig.UseHttpXForwardedProto)
                return _httpContextAccessor.HttpContext.Request.Headers[NopHttpDefaults.HttpXForwardedProtoHeader].ToString().Equals("https", StringComparison.OrdinalIgnoreCase);

            return _httpContextAccessor.HttpContext.Request.IsHttps;
        }

        public bool IsLocalRequest(HttpRequest req)
        {
            throw new NotImplementedException();
        }

        public bool IsStaticResource()
        {
            throw new NotImplementedException();
        }

        public string ModifyQueryString(string url, string key, params string[] values)
        {
            throw new NotImplementedException();
        }

        public T QueryString<T>(string name)
        {
            throw new NotImplementedException();
        }

        public string RemoveQueryString(string url, string key, string value = null)
        {
            throw new NotImplementedException();
        }

        public void RestartAppDomain(bool makeRedirect = false)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Utilities
        /// <summary>
        /// 检查当前的HTTP请求是否可用
        /// </summary>
        /// <returns></returns>
        protected virtual bool IsRequestAvailable()
        {
            if (_httpContextAccessor?.HttpContext == null)
                return false;

            try
            {
                if (_httpContextAccessor.HttpContext.Request == null)
                    return false;
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}

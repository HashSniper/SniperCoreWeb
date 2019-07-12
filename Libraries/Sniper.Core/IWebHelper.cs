using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core
{
    public interface IWebHelper
    {
        /// <summary>
        /// 获取Url引用
        /// </summary>
        /// <returns></returns>
        string GetUrlReferrer();

        /// <summary>
        /// 获取当前ip地址
        /// </summary>
        /// <returns></returns>
        string GetCurrentIpAddress();

        /// <summary>
        /// 获取当前页面url
        /// </summary>
        /// <param name="includeQueryString"></param>
        /// <param name="useSsl"></param>
        /// <param name="lowercaseUrl"></param>
        /// <returns></returns>
        string GetThisPageUrl(bool includeQueryString, bool? useSsl = false, bool lowercaseUrl = false);

        /// <summary>
        /// 当前连接是否安全
        /// </summary>
        /// <returns></returns>
        bool IsCurrentConnectionSecured();

        /// <summary>
        /// 获取存储主机
        /// </summary>
        /// <param name="useSsl"></param>
        /// <returns></returns>
        string GetStoreHost(bool useSsl);

        /// <summary>
        /// 获取存储位置
        /// </summary>
        /// <param name="userUrl"></param>
        /// <returns></returns>
        string GetStoreLocation(bool? userUrl = null);

        /// <summary>
        /// s是否为静态资源
        /// </summary>
        /// <returns></returns>
        bool IsStaticResource();

        /// <summary>
        /// 更改查询字符串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        string ModifyQueryString(string url, string key, params string[] values);

        /// <summary>
        /// 移除url参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        string RemoveQueryString(string url, string key, string value = null);

        /// <summary>
        ///通过名称查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        T QueryString<T>(string name);

        /// <summary>
        /// 重启应用程序域
        /// </summary>
        /// <param name="makeRedirect"></param>
        void RestartAppDomain(bool makeRedirect = false);

        /// <summary>
        /// 是否重定向到新的位置
        /// </summary>
        bool IsRequestBeingRedirected { get; }

        /// <summary>
        /// 是否使用post方式重定向
        /// </summary>
        bool IsPostBeingDone { get; set; }

        /// <summary>
        /// 获取当前http请求协议
        /// </summary>
        string CurrentRequestProtocol { get; }

        /// <summary>
        /// 是否引用本地主机
        /// </summary>
        bool IsLocalRequest(HttpRequest req);

        /// <summary>
        /// 获取请求的完整路径
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        string GetRawUrl(HttpRequest request);

        /// <summary>
        /// 是否为ajax请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool IsAjaxRequest(HttpRequest request);
    }
}

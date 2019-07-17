using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Helpers
{
    public partial interface IUserAgentHelper
    {
        /// <summary>
        /// 请求是否由搜索引擎（网络爬虫）提出
        /// </summary>
        /// <returns></returns>
        bool IsSearchEngine();

        /// <summary>
        /// 请求是否由移动设备发出
        /// </summary>
        /// <returns></returns>
        bool IsMobileDevice();

        /// <summary>
        /// 请求是否由IE8浏览器发出
        /// </summary>
        /// <returns></returns>
        bool IsIe8();

    }
}

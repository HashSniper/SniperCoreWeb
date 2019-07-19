using Sniper.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Sniper.Services.Helpers
{
    public class BrowscapXmlHelper
    {
        private Regex _crawlerUserAgentsRegexp;
        private readonly INopFileProvider _fileProvider;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="userAgentStringsPath">User agent file path</param>
        /// <param name="crawlerOnlyUserAgentStringsPath">User agent with crawlers only file path</param>
        /// <param name="fileProvider">File provider</param>
        public BrowscapXmlHelper(string userAgentStringsPath, string crawlerOnlyUserAgentStringsPath, INopFileProvider fileProvider)
        {
            _fileProvider = fileProvider;

            Initialize(userAgentStringsPath, crawlerOnlyUserAgentStringsPath);
        }

        /// <summary>
        /// 初始化操作
        /// </summary>
        /// <param name="userAgentStringsPath"></param>
        /// <param name="crawlerOnlyUserAgentStringsPath"></param>
        private void Initialize(string userAgentStringsPath, string crawlerOnlyUserAgentStringsPath)
        {

        }

        /// <summary>
        /// 确定用户代理是否为爬网程序
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        public bool IsCrawler(string userAgent)
        {
            return _crawlerUserAgentsRegexp.IsMatch(userAgent);
        }

    }
}

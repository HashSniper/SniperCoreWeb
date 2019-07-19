using Microsoft.AspNetCore.Http;
using Sniper.Core.Domain.Localization;
using Sniper.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Sniper.Services.Localization
{
    public static class LocalizedUrlExtenstions
    {
        /// <summary>
        /// URL是否已本地化（包含SEO代码）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="pathBase"></param>
        /// <param name="isRawPath"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static bool IsLocalizedUrl(this string url, PathString pathBase, bool isRawPath, out Language language)
        {
            language = null;
            if (string.IsNullOrEmpty(url))
                return false;

            if (isRawPath)
            {
                url = url.RemoveApplicationPathFromRawUrl(pathBase);
            }

            var firstSegment = url.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? string.Empty;

            if (string.IsNullOrEmpty(firstSegment))
            {
                return false;
            }

            var languageService = EngineContext.Current.Resolve<ILanguageService>();

            language = languageService.GetAllLanguages().FirstOrDefault(urlLanguage => urlLanguage.UniqueSeoCode.Equals(firstSegment, StringComparison.InvariantCultureIgnoreCase));

            return language?.Published ?? false;
        }

        /// <summary>
        /// 从原始URL删除应用程序路径
        /// </summary>
        /// <param name="rawUrl"></param>
        /// <param name="pathBase"></param>
        /// <returns></returns>
        public static string RemoveApplicationPathFromRawUrl(this string rawUrl, PathString pathBase)
        {
            new PathString(rawUrl).StartsWithSegments(pathBase, out PathString result);
            return WebUtility.UrlDecode(result);
        }
    }
}

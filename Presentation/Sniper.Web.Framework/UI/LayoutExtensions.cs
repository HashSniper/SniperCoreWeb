using Microsoft.AspNetCore.Mvc.Rendering;
using Sniper.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework.UI
{
    public static class LayoutExtensions
    {
        /// <summary>
        /// 将CSS class 附加到<！[CDATA [<head>]]>元素
        /// </summary>
        /// <param name="html"></param>
        /// <param name="part"></param>
        public static void AppendPageCssClassParts(this IHtmlHelper html, string part)
        {
            var pageHeadBuilder = EngineContext.Current.Resolve<IPageHeadBuilder>();
            pageHeadBuilder.AppendPageCssClassParts(part);
        }
    }
}

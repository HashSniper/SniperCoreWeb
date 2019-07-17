using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework.Localization
{
    public class LocalizedRoute : Route
    {
        #region Fields

        private readonly IRouter _target;
        private bool? _seoFriendlyUrlsForLanguagesEnabled;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="target">Target</param>
        /// <param name="routeName">Route name</param>
        /// <param name="routeTemplate">Route template</param>
        /// <param name="defaults">Defaults</param>
        /// <param name="constraints">Constraints</param>
        /// <param name="dataTokens">Data tokens</param>
        /// <param name="inlineConstraintResolver">Inline constraint resolver</param>
        public LocalizedRoute(IRouter target, string routeName, string routeTemplate, RouteValueDictionary defaults,
            IDictionary<string, object> constraints, RouteValueDictionary dataTokens, IInlineConstraintResolver inlineConstraintResolver)
            : base(target, routeName, routeTemplate, defaults, constraints, dataTokens, inlineConstraintResolver)
        {
            _target = target ?? throw new ArgumentNullException(nameof(target));
        }

        #endregion
    }
}

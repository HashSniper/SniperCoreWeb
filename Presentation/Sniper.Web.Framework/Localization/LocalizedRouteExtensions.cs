using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework.Localization
{
    public static class LocalizedRouteExtensions
    {
        /// <summary>
        /// 添加路由
        /// </summary>
        /// <param name="routeBuilder"></param>
        /// <param name="name"></param>
        /// <param name="template"></param>
        /// <param name="defaults"></param>
        /// <returns></returns>
        public static IRouteBuilder MapLocalizedRoute(this IRouteBuilder routeBuilder, string name, string template, object defaults)
        {
            return MapLocalizedRoute(routeBuilder, name, template, defaults, constraints: null);
        }

        /// <summary>
        /// 添加路由
        /// </summary>
        /// <param name="routeBuilder"></param>
        /// <param name="name"></param>
        /// <param name="template"></param>
        /// <param name="defaults"></param>
        /// <param name="constraints"></param>
        /// <returns></returns>
        public static IRouteBuilder MapLocalizedRoute(this IRouteBuilder routeBuilder, string name, string template, object defaults, object constraints)
        {
            return MapLocalizedRoute(routeBuilder, name, template, defaults, constraints, dataTokens: null);
        }

        /// <summary>
        /// 添加路由
        /// </summary>
        /// <param name="routeBuilder"></param>
        /// <param name="name"></param>
        /// <param name="template"></param>
        /// <param name="defaults"></param>
        /// <param name="constraints"></param>
        /// <param name="dataTokens"></param>
        /// <returns></returns>
        public static IRouteBuilder MapLocalizedRoute(this IRouteBuilder routeBuilder, string name, string template, object defaults, object constraints, object dataTokens)
        {
            if (routeBuilder.DefaultHandler == null)
            {
                throw new ArgumentNullException(nameof(routeBuilder));
            }

            var inlineConstraintResolver = routeBuilder.ServiceProvider.GetRequiredService<IInlineConstraintResolver>();
            routeBuilder.Routes.Add(new LocalizedRoute(routeBuilder.DefaultHandler, name, template,
    new RouteValueDictionary(defaults), new RouteValueDictionary(constraints), new RouteValueDictionary(dataTokens),
    inlineConstraintResolver));

            return routeBuilder;
        }
    }
}

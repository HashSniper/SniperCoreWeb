using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Routing;
using Sniper.Core.Infrastructure;

namespace Sniper.Web.Framework.Mvc.Routing
{
    public class RoutePublisher : IRoutePublisher
    {
        #region Fields
        protected readonly ITypeFinder _typeFinder;

        #endregion

        #region Ctor
        public RoutePublisher(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }
        #endregion

        #region Methods
        public virtual void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            var routeProviders = _typeFinder.FindClassesOfType<IRouteProvider>();

            var instances = routeProviders.Select(routeProvider => (IRouteProvider)Activator.CreateInstance(routeProvider))
                .OrderByDescending(routeProvider => routeProvider.Priority);

            foreach (var routeProvider in instances)
            {
                routeProvider.RegisterRoutes(routeBuilder);
            }
        }
        #endregion
    }
}

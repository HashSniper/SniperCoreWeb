using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework.Mvc.Routing
{
    public interface IRoutePublisher
    {
        void RegisterRoutes(IRouteBuilder routeBuilder);
    }
}

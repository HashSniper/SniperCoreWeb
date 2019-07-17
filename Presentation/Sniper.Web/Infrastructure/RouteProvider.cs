using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Sniper.Web.Framework.Localization;
using Sniper.Web.Framework.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sniper.Web.Infrastructure
{
    public partial class RouteProvider : IRouteProvider
    {
        public int Priority
        {
            get { return 0; }
        }

        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(name: "areaRoute", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


            //home page
            routeBuilder.MapLocalizedRoute("Homepage", "",
                new { controller = "Home", action = "Index" });
        }
    }
}

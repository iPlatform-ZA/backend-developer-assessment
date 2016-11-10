using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Backend_Assessment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Help Area",
                "",
                new { controller = "Help", action = "Index" }
            ).DataTokens = new RouteValueDictionary(new { area = "HelpPage" });
        }
    }
}

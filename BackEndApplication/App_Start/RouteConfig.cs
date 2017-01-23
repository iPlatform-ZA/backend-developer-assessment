using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BackEndApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "Search",
                url: "artist/search/{searchCriteria}/{pageNumber}/{pageSize}",
                defaults: new { controller = "Artist", action = "Search", searchCriteria = "", pageNumber = 1, pageSize = 10 }
            );

            routes.MapRoute(
             name: "Releases",
             url: "artist/{artistId}/releases",
             defaults: new { controller = "Artist", action = "Releases" }
            );

            routes.MapRoute(
             name: "Albums",
             url: "artist/{artistId}/albums",
             defaults: new { controller = "Artist", action = "Albums" }
            );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

        }
    }
}
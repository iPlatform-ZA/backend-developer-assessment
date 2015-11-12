using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BDA
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "ApiSearch",                                           // Route name
                "artist/search/{search_criteria}/{page_number}/{page_size}",                            // URL with parameters
                new { controller = "Api", action = "Search", page_number = UrlParameter.Optional, page_size = UrlParameter.Optional }  // Parameter defaults
            );

           // /artist/6c44e9c22-ef82-4a77-9bcd-af6c958446d6/albums
            routes.MapRoute(
                "GetTopAlbums",                                           // Route name
                "artist/{artist_id}/albums",                            // URL with parameters
                new { controller = "Api", action = "GetTopAlbums" }  // Parameter defaults
            );

            // /artist/6c44e9c22-ef82-4a77-9bcd-af6c958446d6/albums
            routes.MapRoute(
                "GetReleases",                                           // Route name
                "artist/{artist_id}/releases",                            // URL with parameters
                new { controller = "Api", action = "GetReleases" }  // Parameter defaults
            );

        

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
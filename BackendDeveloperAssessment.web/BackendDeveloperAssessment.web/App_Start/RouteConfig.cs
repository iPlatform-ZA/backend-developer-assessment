using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BackendDeveloperAssessment.web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
               name: "ArtistSearch",
               url: "{controller}/{action}/{search_criteria}/{page_number}/{page_size}",
               defaults: new { controller = "Artist", action = "Search", search_criteria = UrlParameter.Optional, page_number = UrlParameter.Optional, page_size = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "ArtistRelease",
              url: "{controller}/{artist_id}/{action}",
              defaults: new { controller = "Artist", action = "Releases", artist_id = UrlParameter.Optional }
          );
        }
    }
}

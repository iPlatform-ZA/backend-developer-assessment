using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ArtistWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{Id}",
                defaults: new { Id = RouteParameter.Optional}
            );

            config.Routes.MapHttpRoute(
                name: "SearchApi",
                routeTemplate: "api/{controller}/{action}/{artistName}/{pageNumber}/{pageSize}",
                defaults: new
                {
                    action = "Search",
                    artistName = RouteParameter.Optional,
                    pageNumber = 1,
                    pageSize = 10
                },
                constraints: new { action = "Search" }
            );

            config.Routes.MapHttpRoute(
                name: "ReleaseApi",
                routeTemplate: "api/{controller}/{artistId}/{action}",
                defaults: new {  },
                constraints: new { action = "Releases" }
            );


            config.Routes.MapHttpRoute(
                name: "AlbumApi",
                routeTemplate: "api/{controller}/{artistIdentifier}/{action}",
                defaults: new { },
                constraints: new { action = "Albums" }
            );



            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}

using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace IplatformBEAssessment
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            IKernel kernel;
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Albumsapi",
                routeTemplate:"api/{controller}/{identifier}/album",
                defaults: new { controller = "Artist", action = "Albums" }
                );

            config.Routes.MapHttpRoute(
               name: "ReleaseApi",
               routeTemplate: "api/{controller}/{artist_Id}/releases",
               defaults: new { controller = "Artist", action = "Releases" }
               );

            config.Routes.MapHttpRoute(
                name: "SearchApi",
                routeTemplate: "api/{controller}/{action}/{search_criteria}/{page_number}/{page_size}",
                defaults: new 
                            { 
                                page_number = 1, 
                                page_size = 2
                            }
                );

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            
        }
    }
}

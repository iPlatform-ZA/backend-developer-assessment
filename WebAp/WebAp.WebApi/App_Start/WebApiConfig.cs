using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;


namespace WebAp.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
           
            config.Routes.MapHttpRoute(
              name: "artistsAll",
              routeTemplate: "api/artists/search/",
              defaults: new { controller = "artists", action = "GetAllArtists", artistName = RouteParameter.Optional }
          );


            config.Routes.MapHttpRoute(
                name: "artists",
                routeTemplate: "api/artists/search/{artistName}",
                defaults: new { controller = "artists", action = "GetArtistsByName", artistName = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "artistsPagination",
               routeTemplate: "api/artists/search/{artistName}/{pageNumber}/{pageSize}",
               defaults: new { controller = "artists", action = "GetArtistByPagination", artistName = RouteParameter.Optional, pageNumber = RouteParameter.Optional, pageSize = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
              name: "artistsByID",
              routeTemplate: "api/artists/GetArtist/{artistID}",
              defaults: new { controller = "artists", action = "GetArtistByID", artistID = RouteParameter.Optional }
          );


            //return json by default
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //changed the contract resolver of the serialization settings to use Camel Case resolver
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        }

    }
}


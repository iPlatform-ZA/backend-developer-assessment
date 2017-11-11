using backend_developer_assessment.DAL;
using backend_developer_assessment.DAL.UoW;
using backend_developer_assessment.Resolver;
using backend_developer_assessment.DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using backend_developer_assessment.DAL.Repositories;

namespace backend_developer_assessment
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IArtistRepository, ArtistRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IArtistService, ArtistService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

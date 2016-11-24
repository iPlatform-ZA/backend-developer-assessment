using Backend.Assessment.Context;
using Backend.Assessment.Repositories;
using Backend.Assessment.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Backend.Assessment
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();


            container.Register<DbContext, BackendContext>(Lifestyle.Scoped);
            container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);
            container.Register<IArtistRepository, ArtistRepository>(Lifestyle.Scoped);
            container.Register<IAliasRepository, AliasRepository>(Lifestyle.Scoped);
            container.Register<IArtistService, ArtistService>(Lifestyle.Scoped);


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            
        
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}

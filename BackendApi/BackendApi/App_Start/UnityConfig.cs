using BackendApi.Models;
using BackendApi.Services;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using System.Web.Http;
using Unity.WebApi;

namespace BackendApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IDbContext, ArtistContext>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebAp.WebApi.App_Start;

namespace WebAp.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.RegisterMappings(); //initialising the automaper
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}

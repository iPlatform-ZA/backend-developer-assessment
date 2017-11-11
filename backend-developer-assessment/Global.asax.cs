using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace backend_developer_assessment
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Check if log path exist. If not don't start serilog.
            if (ConfigurationManager.AppSettings["LogsPath"] != null) {
                string logPath = ConfigurationManager.AppSettings["LogsPath"].ToString();
                Log.Logger = new LoggerConfiguration()
                 .WriteTo.RollingFile(logPath, LogEventLevel.Verbose)
                 .CreateLogger();
            }
            
        }
    }
}

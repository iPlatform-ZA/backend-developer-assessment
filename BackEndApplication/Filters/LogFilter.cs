using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json;

namespace BackEndApplication.Filters
{
    public class LogFilter : ActionFilterAttribute
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LogFilter));

         public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            log.Debug("------{{------");
            log.Debug(JsonConvert.SerializeObject(filterContext.RouteData));            
        }

         public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            log.Debug(JsonConvert.SerializeObject(filterContext.Result));
            log.Debug("------}}------");
        }
        
       
    }
}
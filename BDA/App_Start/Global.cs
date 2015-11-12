using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDA
{
    public static class Global
    {
       
        public static string GlobalUri = "";
        public static void SetGlobalUri()
        {
            try
            {

                var absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
                GlobalUri = absoluteUri.Substring(0, absoluteUri.IndexOf(@"/artist/"));
            }
            catch (Exception)
            {

                GlobalUri = "";
            }
        }

    }
}
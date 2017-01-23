using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace BackEndApplication.WebClient
{
    public class ConfigHeaderProvider : IHeaderProvider
    {
        public Dictionary<string, string> GetHeaders()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();

            XmlDocument configDoc = new XmlDocument();

            configDoc.Load(GetFilePath());

            foreach (XmlNode header in configDoc["config"].ChildNodes)
            {
                headers.Add(header.Name, header.InnerText);
            }

            return headers;

        }

        private string GetFilePath()
        {
            return HttpContext.Current.Server.MapPath("/WebClient/HttpHeaders.xml");
        }
    }
}
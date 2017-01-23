using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndApplication.WebClient
{
    public class HardcodedHeaderProvider : IHeaderProvider
    {
        public Dictionary<string, string> GetHeaders()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();

            headers.Add("Accept", "text/html,application/xhtml+xml,application/xml");
            headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
            headers.Add("Accept-Charset", "ISO-8859-1");

            return headers;
        }
    }
}
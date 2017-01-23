using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndApplication.WebClient
{
    public interface IHeaderProvider
    {
        Dictionary<string, string> GetHeaders();
    }
}
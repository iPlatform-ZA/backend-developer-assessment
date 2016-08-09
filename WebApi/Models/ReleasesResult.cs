using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ReleasesResult
    {
        public ReleasesResult()
        {
            Releases = new Release[0];
        }

        public Release[] Releases { get; set; }
    }
}
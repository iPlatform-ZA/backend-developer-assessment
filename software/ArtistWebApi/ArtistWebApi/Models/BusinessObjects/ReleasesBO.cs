using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistWebApi.Models.BusinessObjects
{
    public class ReleasesBO
    {
        public List<ArtistReleaseBO> Releases { get; set; }

        public ReleasesBO()
        { 
        }
    }
}
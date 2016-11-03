using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendDeveloperAssessment.Model
{
    public class ArtistDisplayViewModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public List<String> Alias { get; set; }
    }
}
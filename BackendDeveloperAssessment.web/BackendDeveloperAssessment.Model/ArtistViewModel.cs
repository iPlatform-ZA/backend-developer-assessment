using BackendDeveloperAssessment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendDeveloperAssessment.Model
{
    public class ArtistViewModel
    {
        public List<ArtistDisplayViewModel> Results { get; set; }
        public int NumberOfSearchResults { get; set; }
        public string page { get; set; }
        public string pageSize { get; set; }
        public string NumberOfPages { get; set; }
    }
}
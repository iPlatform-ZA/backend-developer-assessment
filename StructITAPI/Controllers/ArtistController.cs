using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.WebPages;
using ClassLib.Helpers;
using ClassLib.Models;
using Newtonsoft.Json;

namespace StructITAPI.Controllers
{
    [RoutePrefix("Artist")]
    public class ArtistController : ApiController
    {
        [Route("Search/{searchCriteria}/{pageNumber}/{pageSize}")]
        [HttpGet]
        public string Search(string searchCriteria,string pageNumber,string pageSize)
        {
            SearchResults results = new SearchResults(searchCriteria,pageNumber,pageSize);
            return JsonConvert.SerializeObject(results);
        }

        [Route("{artistid}/releases")]
        [HttpGet]
        public string Releases(string artistId)
        {
            return JsonConvert.SerializeObject(APIHelper.GetReleases(artistId));
            
        }
    }
}

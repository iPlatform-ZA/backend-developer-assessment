using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StructITAPI.Controllers
{
    [RoutePrefix("Artist")]
    public class ArtistController : ApiController
    {
        [Route("Search/{searchCriteria}/{pageNumber}/{pageSize}")]
        [HttpGet]
        public bool Search(string searchCriteria,string pageNumber,string pageSize)
        {
            return true;
        }

        [Route("{artistid}/releases")]
        [HttpGet]
        public bool Releases(string artistId)
        {
            return true;
        }
    }
}

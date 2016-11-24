using Backend.Assessment.Repositories;
using Backend.Assessment.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Assessment.Controllers
{
    [RoutePrefix("artist")]
    public class ArtistController : ApiController
    {
        private IArtistService ArtistService { get; set; }

        public ArtistController(IArtistService artistService)
        {
            ArtistService = artistService;
        }

        [HttpGet]
        [Route("search/{criteria}/{pageNumber}/{pageSize}")]
        public HttpResponseMessage Search(string criteria, int pageNumber, int pageSize)
        {
            HttpResponseMessage response = null;

            try
            {
                var searchResults = ArtistService.Search(criteria, pageNumber, pageSize);

                response = Request.CreateResponse(HttpStatusCode.GatewayTimeout, searchResults);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.GatewayTimeout, ex);
            }

            return response;
        }
    }
}

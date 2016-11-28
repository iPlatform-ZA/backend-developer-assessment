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
                //Pass results to be processed by Service Layer
                var searchResults = ArtistService.Search(criteria, pageNumber, pageSize);

                response = Request.CreateResponse(HttpStatusCode.OK, searchResults);
            }
            catch (Exception ex)
            {
                //If crash of any sort, return the exception with a timeout http status
                response = Request.CreateResponse(HttpStatusCode.GatewayTimeout, ex);
            }

            return response;
        }

        [HttpGet]
        [Route("{artistId}/albums")]
        public HttpResponseMessage GetAlbumsByArtist(Guid artistId)
        {
            HttpResponseMessage response = null;
            try
            {
                //Pass the results to be processed by the Service Layer
                var results = ArtistService.GetAlbumByArtist(artistId);

                response = Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                //If crash of any sort, return the exception with a timeout http status
                response = Request.CreateResponse(HttpStatusCode.GatewayTimeout, ex);
            }

            return response;
        }
    }
}

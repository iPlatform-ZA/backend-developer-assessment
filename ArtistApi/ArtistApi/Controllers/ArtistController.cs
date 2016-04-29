using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ArtistApi.Models;

using ArtistDAL;
using ArtistDAL.Models;

namespace ArtistApi.Controllers
{
    public class ArtistController :
        ApiController
    {
        public const int DefaultPageSize = 10;

        private ArtistContext context = new ArtistContext();
        
        [HttpGet]
        public IEnumerable<Artist> GetArtists()
        {
            return context.Artists
                          .ToList();
        }

        [HttpGet]
        public Artist GetArtist(Guid id)
        {
            return context.Artists
                          .FirstOrDefault(a => a.Id == id);
        }

        [HttpGet]
        [Route("api/artist/search/{searchCriteria}")]
        public HttpResponseMessage Search(string searchCriteria)
        {
            return Search(searchCriteria, 1, DefaultPageSize);
        }

        [HttpGet]
        [Route("api/artist/search/{searchCriteria}/{pageNumber:int}/{pageSize:int}")]
        public HttpResponseMessage Search(string searchCriteria, int pageNumber, int pageSize)
        {
            searchCriteria = searchCriteria.ToLower();
            
            var artists = context.Artists
                                 .Where(a => a.Name.ToLower().StartsWith(searchCriteria) ||
                                             a.Aliases.ToLower().Contains(searchCriteria))
                                 .OrderBy(a => a.Name);

            if (artists.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            var result = new SearchResult(artists, pageNumber, pageSize);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/artist/{artistId}/releases")]
        public HttpResponseMessage Releases(Guid artistId)
        {
            var result = MusicBrainz.Search.Release(arid: artistId.ToString());

            return Request.CreateResponse();
        }
    }
}

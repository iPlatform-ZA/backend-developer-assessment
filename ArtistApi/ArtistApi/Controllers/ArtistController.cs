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

            int offset = pageSize * (pageNumber - 1);

            IQueryable<Artist> artists = context.Artists
                                                .Where(a => a.Name.ToLower().StartsWith(searchCriteria) ||
                                                            a.Aliases.ToLower().Contains(searchCriteria))
                                                .OrderBy(a => a.Name)
                                                .Skip(offset)
                                                .Take(pageSize);

            if (artists.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            var result = new SearchResult
            {
                Results = artists.ToList()
                                 .Select(a => new SearchResultArtist
                {
                    Name = a.Name,
                    Country = a.Country,
                    Aliases = a.Aliases.Split(',')
                })
            };

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}

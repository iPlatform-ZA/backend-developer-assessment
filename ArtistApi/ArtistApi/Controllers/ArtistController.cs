using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ArtistApi.Models;

using ArtistService.Services;

namespace ArtistApi.Controllers
{
    public class ArtistController :
        ApiController
    {
        public const int DefaultPageSize = 10;

        private IArtistService service;
        
        public ArtistController(IArtistService service)
        {
            this.service = service;
        }
        
        [HttpGet]
        public HttpResponseMessage GetArtists()
        {
            var artists = service.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, artists);
        }

        [HttpGet]
        public HttpResponseMessage GetArtist(Guid id)
        {
            var artist = service.Get(id);

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        [HttpGet]
        [Route("api/artist/search/{searchCriteria}")]
        public HttpResponseMessage Search(string searchCriteria)
        {
            return Search(searchCriteria, 1, DefaultPageSize);
        }

        [HttpGet]
        [Route("api/artist/search/{searchName}/{pageNumber:int}/{pageSize:int}")]
        public HttpResponseMessage Search(string searchName, int pageNumber, int pageSize)
        {
            var artists = service.SearchArtists(searchName);
            var result = new SearchResult(artists, pageNumber, pageSize);

            if (!result.HasResults())
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/artist/{artistId}/releases")]
        public HttpResponseMessage Releases(Guid artistId)
        {
            var artist = service.Get(artistId);

            if (artistId == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var releases = MusicBrainz.Search.Release(arid: artist.Id.ToString());

            if (releases.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, releases.Data);
        }

        [HttpGet]
        [Route("api/artist/{artistId}/albums")]
        public HttpResponseMessage Albums(Guid artistId)
         {
            var artist = service.Get(artistId);

            if (artistId == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var release = MusicBrainz.Search.Release(arid: artist.Id.ToString(), limit: 10);
            var releases = new List<Release>();

            foreach (var releaseData in release.Data)
            {
                releases.Add(Release.CreateFromReleaseData(artist.Id, releaseData));
            }

            return Request.CreateResponse(HttpStatusCode.OK, releases);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {

            }
        }
    }
}

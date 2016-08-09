using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("artist")]
    public class ArtistController : ApiController
    {
        private IArtistFactory _artistFactory;
        private IReleaseRepository _releaseRepository;

        public ArtistController(): this(new Factories.ArtistFactory(new Repositories.ArtistRepository(), new MusicBrainzArtistAlbumLinkProvider()), new Repositories.ReleaseRepository())
        {
        }

        public ArtistController(IArtistFactory artistFactory, IReleaseRepository releaseRepository)
        {
            _artistFactory = artistFactory;
            _releaseRepository = releaseRepository;
        }

        [HttpGet]
        [Route("search/{name}/{pageNumber:int?}/{pageSize:int?}")]
        public SearchResult<CompositeArtist> Search(string name, int pageNumber = 1, int pageSize = 10)
        {
            SearchResult<CompositeArtist> pagedResult;

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            try
            {
                var searchResult = _artistFactory.FindByNameOrAlias(name);

                pagedResult = new SearchResult<CompositeArtist>(searchResult, pageSize, 1);
            }
            catch (Exception)
            {
                // TODO: log error and notify admin

                pagedResult = new SearchResult<CompositeArtist>(new List<CompositeArtist>());
            }


            return pagedResult;
        }

        [HttpGet]
        [Route("{artistId}/releases")]
        public ReleasesResult GetReleasesByArtistId(Guid artistId)
        {
            ReleasesResult result = new ReleasesResult();

            CompositeArtist artist = _artistFactory.GetById(artistId);

            if (artist != null)
            {
                result.Releases = _releaseRepository.GetReleaseByArtistId(artistId).ToArray();
            }

            return result;
        }
    }
}
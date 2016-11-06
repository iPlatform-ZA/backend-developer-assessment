using AutoMapper.QueryableExtensions;
using Backend_Assessment.EntityModels;
using Backend_Assessment.Paging;
using Backend_Assessment.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend_Assessment.Controllers
{
    public class ArtistController : ApiController
    {
        private readonly Assessment_DBEntities _db;
        private readonly MusicBrainzService _musicBrainzService;

        public ArtistController()
        {
            _db = new Assessment_DBEntities();
            _musicBrainzService = new MusicBrainzService();
        }

        [HttpGet]
        [Route(template: "api/artist/search/{criteria}")]
        [Route(template: "api/artist/search/{criteria}/{pageNumber}/{pageSize}")]
        public PagedList<Models.Artist> Search(string criteria, int pageNumber = 1, int? pageSize = null)
        {
            var data = _db.Artists.Where(x => x.Name.StartsWith(criteria) || x.ArtistAliases.Any(al => al.Alias.StartsWith(criteria))).ProjectTo<Models.Artist>().OrderBy(x => x.Name);
            var pagedList = new PagedList<Models.Artist>(data, pageNumber > 0 ? pageNumber : 1, pageSize ?? data.Count());

            if (pagedList.NumberOfPages < pageNumber)
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                responseMessage.Content = new StringContent($"Page Number may not exceed Number Of Pages({pagedList.NumberOfPages}).");
                throw new HttpResponseException(responseMessage);
            }
                

            return pagedList;
        }

        [HttpGet]
        [Route(template: "api/artist/{artistId}/releases")]
        public IQueryable<Models.Release> ReleaseSearch(string artistId)
        {
            try
            {
                return _musicBrainzService.GetReleases(artistId).ProjectTo<Models.Release>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}



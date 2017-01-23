using MusicBrainz.Api.Models;
using MusicBrainz.Services.DataServices;
using MusicBrainz.Services.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MusicBrainz.Api.Controllers
{
    public class SearchController : ApiController
    {
        private readonly IArtistService _artistService;
        private readonly IWebRequestService _webRequestService;

        public SearchController()
        {
            // Dependency Injection. However a third party library has been avoided as suggested.
            _artistService = new ArtistService();
            _webRequestService = new WebRequestService();
        }

        // GET api/search
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET artist/search/joh/1/5
        [System.Web.Http.Route("artist/search/{searchCriteria}/{pageNumber}/{pageSize}")]
        public HttpResponseMessage Get(string searchCriteria, int? pageNumber = 1, int? pageSize = 2)
        {
            var records = _artistService.GetArtists(searchCriteria);
            if (records == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No records found");
            }

            var total = records.Count();
            var totalPages = (int)Math.Ceiling((double)total / pageSize.Value);
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                int start = (pageNumber.Value - 1) * pageSize.Value;
                records = records.Skip(start).Take(pageSize.Value).ToList();
            }

            var results = new List<Result>();
            foreach (var record in records)
            {
                results.Add(new Result { Name = record.Artistname, Alias = record?.Aliases?.Split(',').ToList<string>(), Country = record.Country });
            }

            var rs = new ResultViewModel
            {
                Results = results,
                NumberOfPages = totalPages,
                NumberOfResults = total,
                Page = pageNumber.Value,
                PageSize = pageSize.Value
            };
            //return Json(rs);
            return Request.CreateResponse(HttpStatusCode.OK, rs);
        }

        // GET artist/<artist_id>/releases 
        [System.Web.Http.HttpGet, System.Web.Http.Route("artist/{artistId:guid}/releases")]
        public HttpResponseMessage GetAlbums(string artistId)
        {
            var mbIdExists = _artistService.MbIdExists(artistId);
            if (!mbIdExists)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "MbId Not Found");
            }

            var records = _webRequestService.GetReleases(artistId);

            if (records == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "MbId Not Found");
            }

            var results = new List<Releases>();

            foreach (var record in records.Data)
            {
                var t = record.Artistcredit.Select(x => new OtherArtist { Id = x?.Artist?.Id , Name = x?.Artist?.Name }).ToList();
                results.Add(new Releases { ReleaseId = record.Id, Label = record.Labelinfolist.FirstOrDefault()?.Label?.Name, NumberOfTracks = record.Mediumlist.Trackcount, Status = record.Status, Title = record.Title, OtherArtists = t });
            }

            var vm = new ReleasesViewModel { Releases = results };
            return Request.CreateResponse(HttpStatusCode.OK, vm);
        }
    }
}

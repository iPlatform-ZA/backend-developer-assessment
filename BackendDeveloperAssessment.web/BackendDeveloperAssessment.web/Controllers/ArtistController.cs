using BackendDeveloperAssessment.IRepository;
using BackendDeveloperAssessment.IRepository.IUtilities;
using BackendDeveloperAssessment.Manager;
using BackendDeveloperAssessment.Model;
using BackendDeveloperAssessment.Model.Release;
using BackendDeveloperAssessment.Repository;
using BackendDeveloperAssessment.Repository.Utilities;
using BackendDeveloperAssessment.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackendDeveloperAssessment.web.Controllers
{
    public class ArtistController : Controller
    {
        IArtistRepository artistRepository;
        IAliasRepository aliasRepository;
        IPagerUtility<ArtistDisplayViewModel> pagerUtility;

        BackendDeveloperAssessmentDbContext dbContext;
        ArtistManager artistManager;

        public ArtistController()
        {
            dbContext = new BackendDeveloperAssessmentDbContext();

            artistRepository = new ArtistRepository(dbContext);
            aliasRepository = new AliasRepository(dbContext);

            pagerUtility = new PagerUtility<ArtistDisplayViewModel>();

            artistManager = new ArtistManager(artistRepository, aliasRepository, pagerUtility);

        }
        // GET: Artist
        public JsonResult Search(string search_criteria, int page_number = 1, int page_size = 10)
        {
            var resultsCount = artistManager.GetAllCount(search_criteria);
            var filteredResults = artistManager.Search(search_criteria, page_number, page_size);

            var artistVM = new ArtistViewModel
            {
                Results = filteredResults,
                NumberOfSearchResults = resultsCount,
                page = string.Format("{0}", page_number),
                pageSize = string.Format("{0}", page_size),
                NumberOfPages = string.Format("{0}", resultsCount <= page_size ? 1 : ((resultsCount / page_size) + 1))
            };

            return Json(artistVM, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Releases(string artist_id)
        {
            WebServiceUtility<releaseData> a = new WebServiceUtility<releaseData>();
            var releasesdata = a.JsonSer(a.Get("http://musicbrainz.org/ws/2/release/?query=arid:" + artist_id + "&fmt=json"));

            return Json(releasesdata.releases, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Albums(string artist_id)
        {
            WebServiceUtility<releaseAlbumData> a = new WebServiceUtility<releaseAlbumData>();
            var releasesdata = a.JsonSer(a.Get("http://musicbrainz.org/ws/2/release/?query=type:album%20AND%20arid:" + artist_id + "&fmt=json"));

            return Json(releasesdata.releases.Take(10), JsonRequestBehavior.AllowGet);
        }
    }
}
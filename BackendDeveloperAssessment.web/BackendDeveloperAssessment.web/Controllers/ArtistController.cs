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
            WebServiceUtility<releaseData> a = new WebServiceUtility<releaseData>();
            var asss = a.JsonSer(a.Get("http://musicbrainz.org/ws/2/release/?query=arid:65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab&fmt=json"));


             dbContext = new BackendDeveloperAssessmentDbContext();

            artistRepository = new ArtistRepository(dbContext);
            aliasRepository = new AliasRepository(dbContext);

            pagerUtility = new PagerUtility<ArtistDisplayViewModel>();

            artistManager = new ArtistManager(artistRepository, aliasRepository, pagerUtility);

        }
        // GET: Artist
        public JsonResult Search(string search_criteria, int page_number = 1, int page_size = 10)
        {
            var resultsCount = artistManager.GetAllCount();
            var filteredResults = artistManager.Search(search_criteria, page_number, page_size);

            var artistVM = new ArtistViewModel
            {
                Results = filteredResults,
                NumberOfSearchResults = resultsCount,
                page = string.Format("{0}", page_number),
                pageSize = string.Format("{0}", page_size),
                NumberOfPages = string.Format("{0}", ((resultsCount / page_size) + 1))
            };

            return Json(artistVM, JsonRequestBehavior.AllowGet);
        }
    }
}
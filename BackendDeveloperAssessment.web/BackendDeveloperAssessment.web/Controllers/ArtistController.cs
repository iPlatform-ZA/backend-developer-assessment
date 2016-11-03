using BackendDeveloperAssessment.IRepository;
using BackendDeveloperAssessment.Manager;
using BackendDeveloperAssessment.Model;
using BackendDeveloperAssessment.Repository;
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
        BackendDeveloperAssessmentDbContext dbContext;
        ArtistManager artistManager;

        public ArtistController()
        {
            dbContext = new BackendDeveloperAssessmentDbContext();

            artistRepository = new ArtistRepository(dbContext);
            aliasRepository = new AliasRepository(dbContext);

            artistManager = new ArtistManager(artistRepository, aliasRepository);

        }
        // GET: Artist
        public JsonResult Search(string search_criteria, int page_number = 1, int page_size = 10)
        {
            var results = artistManager.GetAll();
            var filteredResults = artistManager.Search(results, search_criteria, page_number, page_size);

            var artistVM = new ArtistViewModel
            {
                Results = filteredResults,
                NumberOfSearchResults = results.Count,
                page = string.Format("{0}", page_number),
                pageSize = string.Format("{0}", page_size),
                NumberOfPages = string.Format("{0}", ((results.Count / page_size) + 1))
            };

            return Json(artistVM, JsonRequestBehavior.AllowGet);
        }
    }
}
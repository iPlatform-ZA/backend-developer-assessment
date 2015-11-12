using BDA.Contracts;
using BDA.Models;
using BDA.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDA.Controllers
{
    public class ApiController : Controller
    {
        private IArtistService artistService;

        public ApiController()
        {
            artistService = new ArtistService();
            Global.SetGlobalUri();

        }
        

        public JsonResult GetAll()
        {
            var result = artistService.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        //artist/search/<search_criteria>/<page_number>/<page_size>
        public ContentResult Search(string search_criteria, string page_number, string page_size)
        {
            var result = JsonConvert.SerializeObject(artistService.Search(search_criteria, page_number, page_size));
            return Content(result, "application/json");
        }


        public ContentResult GetTopAlbums(string artist_id)
        {
            var result = JsonConvert.SerializeObject(artistService.GetTopAlbums(artist_id));
            return Content(result, "application/json");
        }

        public ContentResult GetReleases(string artist_id)
        {
            var result = JsonConvert.SerializeObject(artistService.GetReleases(artist_id));
            return Content(result, "application/json");
        }

    }
}
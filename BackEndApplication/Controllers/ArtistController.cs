using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEndApplication.Filters;
using BackEndApplication.Models;
using BackEndApplication.MusicBrains;
using BackEndApplication.Utils;
using Newtonsoft.Json;

namespace BackEndApplication.Controllers
{
    [LogFilter]
    public class ArtistController : Controller
    {
        readonly IArtistRepository artistRepository;

        readonly IMusicBrainsClient musicBrainsClient;

        public ArtistController(IMusicBrainsClient musicBrainsClient,IArtistRepository artistRepository)
        {
            this.musicBrainsClient = musicBrainsClient;

            this.artistRepository = artistRepository;
        }

        public ActionResult Search(string searchCriteria, int pageNumber, int pageSize)
        {  
            var results = artistRepository.Search(searchCriteria, pageNumber, pageSize);

            return Json(results, JsonRequestBehavior.AllowGet);
        }

                
        public ActionResult Releases(string artistId)
        {
            var releases = musicBrainsClient.GetReleasesByArtistId(artistId);

            return Json(releases, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Albums(string artistId)
        {   
            var albums = musicBrainsClient.GetAlbumsByArtistId(artistId);

            return Json(albums, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            artistRepository.Dispose();

            base.Dispose(disposing);
        }
    }
}
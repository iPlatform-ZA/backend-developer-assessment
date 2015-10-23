using System;
using System.IO;
using System.Collections.Generic;
using ArtistSearch.Helpers;
using ArtistSearch.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Serialization;
using AttributeRouting.Web.Http;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using System.Linq;

namespace ArtistSearch.Controllers
{
    [RoutePrefix("api")]
    public class ArtistController : ApiController
    {
        private ArtistEntities db = new ArtistEntities();

        //
        // GET: /Artists/
        //      /api/artist/search/{search_criteria}/{page_number}/{page_size}

        [Route("artist/search/{search_criteria}/{page_number}/{page_size}")]
        [HttpGet]
        public ArtistDetails GetArtist(string search_criteria, int page_number, int page_size)
        {
            var artist = ArtistRepository.FindArtist(search_criteria);
            var ArtistListPaged = new PaginatedList<Artist>(artist, page_number, page_size);
            ArtistDetails ad = new ArtistDetails();

            List<Artist> la = new List<Artist>();

            foreach (Artist a in artist)
            {
                la.Add(a);
            }
            ad.results = la;

            ad.numberOfSearchResults = ArtistListPaged.TotalCount;
            ad.page = ArtistListPaged.PageIndex;
            ad.pageSize = ArtistListPaged.PageSize;
            ad.numberOfPages = ArtistListPaged.TotalPages;

            return ad;
        }


        //
        // GET: /Releases/
        //      api/artist/{id}/albums
        [Route("artist/{id}/albums")]
        [HttpGet]
        public async Task<ReleaseMetadata> GetSearch(string id)
        {
            Artist get = db.Artists.Find(id);
            var jsonTask = await GetJsonAsync(get.Name);

            return jsonTask;
        }

        private static async Task<ReleaseMetadata> GetJsonAsync(String Name)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://musicbrainz.org/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                HttpResponseMessage res = await client.GetAsync(string.Format("ws/2/release/?query=release:{0}", Name.Trim()));
                if (res.IsSuccessStatusCode)
                {
                    var xmlString = await res.Content.ReadAsStringAsync();

                    XmlSerializer serializer = new XmlSerializer(typeof(ReleaseMetadata));

                    ReleaseMetadata result;
                    using (StringReader s = new StringReader(xmlString))
                    {
                        result = (ReleaseMetadata)serializer.Deserialize(s);
                    }

                    return result;
                }
            }

            return new ReleaseMetadata();
        }








        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
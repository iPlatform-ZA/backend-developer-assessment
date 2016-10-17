using BackendApi.Models;
using BackendApi.Services;
<<<<<<< HEAD
using Newtonsoft.Json;
=======
>>>>>>> refs/remotes/origin/master
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
<<<<<<< HEAD
using System.Threading.Tasks;
=======
>>>>>>> refs/remotes/origin/master
using System.Web.Http;

namespace BackendApi.Controllers
{
    [RoutePrefix("artist")]
    public class ArtistController : ApiController
    {
        private readonly IDbContext _context;

        public ArtistController(IDbContext context)
        {
            _context = context;
        }

        [Route("search/{keyword}/{page:int}/{pageSize:int}")]
        public IHttpActionResult Get(string keyword, int page, int pageSize)
        {
            var set = _context.Set<Artist>();
            var artistsQuery = set.Where(x =>
                     x.Name.ToLower().Contains(keyword.ToLower())
                        || x.Country.ToLower().Contains(keyword.ToLower())
                        || x.Aliases.ToLower().Contains(keyword.ToLower()))
                        .OrderBy(x => x.Name).AsQueryable();
<<<<<<< HEAD
            var resultsCount = artistsQuery.ToList().Count;
=======
             var resultsCount = artistsQuery.ToList().Count;
>>>>>>> refs/remotes/origin/master
            var pages = ((resultsCount / pageSize) < 1 ? 1 : ((resultsCount / pageSize) + ((resultsCount % pageSize) == 0 ? 0 : 1)));
            var dataResults = artistsQuery.OrderBy(x => x.Name)
                  .Skip((page - 1) * pageSize).Take(pageSize)
                  .ToList()
                  .Select(a => new Artist()
                  {
                      Country = a.Country,
                      Id = a.Id,
                      Name = a.Name,
<<<<<<< HEAD
                      Alias = a.Aliases.Split(',').ToArray(),
                      Albums= Url.Link("albums",new { id= a.Id })
=======
                      Alias = a.Aliases.Split(',').ToArray()
>>>>>>> refs/remotes/origin/master
                  }).ToArray();
            var result = new ArtistResultModel
            {
                Artist = dataResults,
                CurrentPage = page,
                PageSize = pageSize,
<<<<<<< HEAD
                Pages = pages,
=======
                Pages =pages,
>>>>>>> refs/remotes/origin/master
                ResultsCount = resultsCount

            };
            return Ok(result);
        }
<<<<<<< HEAD
        [HttpGet]
        [Route("{id}/releases")]
        public async Task<IHttpActionResult> Releases(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://musicbrainz.org/ws/2/");
                client.DefaultRequestHeaders.Add("user-agent", "iPlatform/1.0.0 (takaz@live.co.za)");
                client.DefaultRequestHeaders.Add("accept", "applicaion/json");
                var releaseReulst = await client.GetAsync($"release/?query=arid:{id}&fmt=json");
                if (releaseReulst.IsSuccessStatusCode)
                {
                    var releaseContent = await releaseReulst.Content.ReadAsStringAsync();
                    var releases = JsonConvert.DeserializeObject<ArtistReleaseModel>(releaseContent);
                    return Ok(releases);
                }
                return Ok(new ArtistReleaseModel());
            }

        }
        [HttpGet]
        [Route("{id}/albums", Name = "albums")]
        public async Task<IHttpActionResult> Albums(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://musicbrainz.org/ws/2/");
                client.DefaultRequestHeaders.Add("user-agent", "iPlatform/1.0.0 (takaz@live.co.za)");
                client.DefaultRequestHeaders.Add("accept", "applicaion/json");
                var releaseReulst = await client.GetAsync($"release/?query=arid:{id}&fmt=json");
                if (releaseReulst.IsSuccessStatusCode)
                {
                    var albumsContent = await releaseReulst.Content.ReadAsStringAsync();
                    var albumsData = JsonConvert.DeserializeObject<ArtistReleaseModel>(albumsContent);
                    var albums = albumsData.Releases.Where(r => r.ReleaseGroup!=null && r.ReleaseGroup.PrimaryType !=null&& r.ReleaseGroup.PrimaryType.ToLower().Equals("album"));
                    return Ok(albums);
                }
                return Ok(new List<Release>());
            }
        }
=======


>>>>>>> refs/remotes/origin/master

    }
}

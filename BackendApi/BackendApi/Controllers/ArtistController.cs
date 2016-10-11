using BackendApi.Models;
using BackendApi.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
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
             var resultsCount = artistsQuery.ToList().Count;
            var pages = ((resultsCount / pageSize) < 1 ? 1 : ((resultsCount / pageSize) + ((resultsCount % pageSize) == 0 ? 0 : 1)));
            var dataResults = artistsQuery.OrderBy(x => x.Name)
                  .Skip((page - 1) * pageSize).Take(pageSize)
                  .ToList()
                  .Select(a => new Artist()
                  {
                      Country = a.Country,
                      Id = a.Id,
                      Name = a.Name,
                      Alias = a.Aliases.Split(',').ToArray()
                  }).ToArray();
            var result = new ArtistResultModel
            {
                Artist = dataResults,
                CurrentPage = page,
                PageSize = pageSize,
                Pages =pages,
                ResultsCount = resultsCount

            };
            return Ok(result);
        }



    }
}

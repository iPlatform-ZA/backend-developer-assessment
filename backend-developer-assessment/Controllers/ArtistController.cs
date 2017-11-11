using backend_developer_assessment.DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Serilog;
using System.Threading.Tasks;

namespace backend_developer_assessment.Controllers
{
    [RoutePrefix("artist")]
    public class ArtistController : ApiController
    {
        IArtistService _artistService;

        public ArtistController()
        {

        }

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [Route("search/{name}/{pageNumber?}/{pageSize?}")]
        public IHttpActionResult Get(string name, int? pageNumber = 1, int? pageSize = 10)
        {
            try
            {
                var result = _artistService.GetArtists(name, Convert.ToInt32(pageNumber), Convert.ToInt32(pageSize));
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("Parameters(artist/search): name:{0},pageNumber:{1},pageSize:{2}", name, pageNumber, pageSize));
                return InternalServerError();
            }
        }

        [Route("{mbid}/albums")]
        public async Task<IHttpActionResult> Get(string mbid)
        {
            try
            {
                var releases = await _artistService.GetAllArtistReleases(mbid);
                return Ok(releases);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return InternalServerError();
            }
        }

    }
}
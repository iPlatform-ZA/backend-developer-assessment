using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

using Assessment.BusinessLogic.Common;
using Assessment.BusinessLogic.Implementations;
using Assessment.Models.DTO;

namespace Assessment.WebAPI.Controllers
{
    public class ArtistController : ApiController
    {
        //Search Artists
        [HttpGet]
        [Route("artist/search/{search_criteria}/{page_number?}/{page_size?}")]
        public async Task<ResultDTO<ArtistDTO>> GetArtists(string search_criteria, int page_number = 0, int page_size = 10)
        {
            ResultDTO<ArtistDTO> result = new ResultDTO<ArtistDTO>();

            try
            {
                Artist<ArtistDTO> artists = new Artist<ArtistDTO>();
                result = await artists.GetArtists(search_criteria, page_number, page_size);
            }
            catch (Exception ex)
            {
                result = new ResultDTO<ArtistDTO>();
                Logger.LogEvent(ex.ToString());
            }

            return result;
        }

        //Get Artist Albums
        [HttpGet]
        [Route("artist/{artist_id}/releases")]
        public async Task<ResultDTO<ReleaseInfoDTO>> GetReleaseInfo(string artist_id)
        {
            ResultDTO<ReleaseInfoDTO> result = new ResultDTO<ReleaseInfoDTO>();

            try
            {
                Artist<List<ReleaseInfoDTO>> artists = new Artist<List<ReleaseInfoDTO>>();
                result = await artists.GetArtistReleases(artist_id);
            }
            catch (Exception ex)
            {
                Logger.LogEvent(ex.ToString());
            }

            return result;
        }
    }
}

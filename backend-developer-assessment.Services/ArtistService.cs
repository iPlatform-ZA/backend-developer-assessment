using backend_developer_assessment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend_developer_assessment.Entities;

namespace backend_developer_assessment.Services
{
    public class ArtistService : IArtistService
    {
        public Task<IEnumerable<object>> GetAllArtistReleases(string ArtistId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Artist>> GetArtists()
        {
            throw new NotImplementedException();
        }
    }
}

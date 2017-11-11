using backend_developer_assessment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_developer_assessment.Services.Interfaces
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetArtists(int count, int page);
        Task<IEnumerable<object>> GetAllArtistReleases(string ArtistId);
    }
}

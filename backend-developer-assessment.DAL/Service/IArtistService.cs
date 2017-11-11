using backend_developer_assessment.DAL.Dto;
using backend_developer_assessment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_developer_assessment.DAL.Service
{
    public interface IArtistService : IDisposable
    {
        ArtistResultDto GetArtists(string artistName, int pageNum, int pageSize);
        Task<object> GetAllArtistReleases(string ArtistId);
    }
}

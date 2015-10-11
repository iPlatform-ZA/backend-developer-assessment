using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Models.DTO;

namespace Assessment.BusinessLogic.Contracts
{
    public interface IArtist
    {
        List<string> GetArtistAliases(long id);
        Task<ResultDTO<ArtistDTO>> GetArtists(string searchCriteria, int pageNumber, int pageSize);
        Task<List<AlbumDTO>> GetArtistAlbums(string id);
        Task<ResultDTO<ReleaseInfoDTO>> GetArtistReleases(string id);
    }
}

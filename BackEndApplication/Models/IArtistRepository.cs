using System;
using BackEndApplication.Utils;

namespace BackEndApplication.Models
{
    public interface IArtistRepository : IDisposable
    {   
        PagedResult<Artist> Search(string searchCriteria, int pageNumber, int pageSize);
    }
}

using BDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDA.Contracts
{
    public interface IArtistRepository
    {
        IEnumerable<ArtistModel> GetAll();
        IEnumerable<ArtistModel> Search(string searchCriteria, int pageNumber, int pageSize);
    }
}

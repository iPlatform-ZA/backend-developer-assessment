using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_developer_assessment.DAL.Repositories
{
    public interface IArtistRepository : IRepository<Entities.Artist>
    {
        int GetArtistCount();
    }
}

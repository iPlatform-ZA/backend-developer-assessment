using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IReleaseRepository
    {
        IEnumerable<Release> GetReleaseByArtistId(Guid id);        
    }
}

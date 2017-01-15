using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.interfaces
{
    public interface IArtist
    {
        Guid UniqueId { get; set; }
        string ArtistsName { get; set; }
        string Country { get; set; }
        List<string> Aliases { get; set; }
    }
}

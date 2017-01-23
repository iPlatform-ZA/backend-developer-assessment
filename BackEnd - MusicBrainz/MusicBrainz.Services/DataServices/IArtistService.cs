using MusicBrainz.Platform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainz.Services.DataServices
{
    public interface IArtistService
    {
        IList<Artist> GetArtists(string artistName);
        bool MbIdExists(string mbId);
    }
}

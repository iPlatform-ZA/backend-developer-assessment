using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicBrainz.Platform.Domain;
using MusicBrainz.Data;

namespace MusicBrainz.Services.DataServices
{
    public class ArtistService : IArtistService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public IList<Artist> GetArtists(string artistName)
        {
            return unitOfWork.ArtistRepository.Get(x => x.Artistname.Contains(artistName)).ToList();
        }
        public bool MbIdExists(string mbId)
        {
            return unitOfWork.ArtistRepository.Get(x => x.Uniqueidentifier == mbId).Count() > 0;
        }
    }
}

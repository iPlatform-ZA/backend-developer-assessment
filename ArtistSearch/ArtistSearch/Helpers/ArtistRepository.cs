using ArtistSearch.Models;
using System.Linq;

namespace ArtistSearch.Helpers
{
    public class ArtistRepository
    {
        private static ArtistEntities db = new ArtistEntities();

        public static IQueryable<Artist> FindArtist(string query)
        {
            return from artist in db.Artists
                   where artist.Name.Contains(query)
                   orderby artist.Name
                   select artist;
        }
    }
}
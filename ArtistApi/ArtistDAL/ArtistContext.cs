using System.Data.Entity;

using ArtistDAL.Models;

namespace ArtistDAL
{
    public class ArtistContext :
        DbContext
    {
        public ArtistContext()
        {
            Database.SetInitializer(new ArtistDbInitializer());
        }

        public DbSet<Artist> Artists { get; set; }
    }
}

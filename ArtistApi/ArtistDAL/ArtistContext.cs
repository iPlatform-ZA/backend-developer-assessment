using System.Data.Entity;

using ArtistDAL.Models;

namespace ArtistDAL
{
    public class ArtistContext :
        DbContext
    {
        public DbSet<Artist> Artists { get; set; }
    }
}

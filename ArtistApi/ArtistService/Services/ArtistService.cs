using System;
using System.Collections.Generic;
using System.Linq;

using ArtistDAL;
using ArtistDAL.Models;

namespace ArtistService.Services
{
    public class ArtistService :
        IArtistService
    {
        private ArtistContext context;

        public ArtistService(ArtistContext context)
        {
            this.context = context;
        }

        public IEnumerable<Artist> GetAll()
        {
            return context.Artists
                          .ToList();
        }

        public Artist Get(Guid id)
        {
            return context.Artists
                          .FirstOrDefault(a => a.Id == id);
        }

        public IQueryable<Artist> SearchArtists(string searchName)
        {
            searchName = searchName.ToLower();

            return context.Artists
                          .Where(a => a.Name.ToLower().StartsWith(searchName) ||
                                      a.Aliases.ToLower().Contains(searchName))
                          .OrderBy(a => a.Name);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}

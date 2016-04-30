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
            throw new NotImplementedException();
            /*context.Artists
                          .FirstOrDefault(a => a.Id == id)*/
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

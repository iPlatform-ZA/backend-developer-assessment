using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAp.Core.Dto;
using WebApCore.Entities;
using WebApCore.Interfaces;

namespace WebAp.Infrastructure.Repository
{
    public class ArtistRepository : IArtistRepository
    {

        private ArtistContext context;


        public ArtistRepository(ArtistContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Artist> search() // returns all artists
        {
            return context.Artists.AsQueryable();
        }
       
        public IQueryable<Artist> search(string artistName) // returns search based on artist Name
        {
            return context.Artists.AsQueryable().Where(a => a.Name.Contains(artistName));
        }


        public Artist GetArtist(Guid artistID)// returns search based on artist ID
        {
            return context.Artists.Where(a => a.Id==artistID).SingleOrDefault();
        }
        


    }
}
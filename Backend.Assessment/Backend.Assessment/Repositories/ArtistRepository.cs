using System;
using System.Collections.Generic;
using System.Data.Entity;
using Backend.Assessment.Models;
using Backend.Assessment.Context;
using System.Linq;
using System.Data.SqlClient;

namespace Backend.Assessment.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public BackendContext BackendContext
        {
            get { return Context as BackendContext; }
        }

        public ArtistRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Artist> SearchArtist(string criteria)
        {
            return BackendContext.Artists.Where(a => a.Firstname.Contains(criteria) || a.Lastname.Contains(criteria));
        }
        
    }
}
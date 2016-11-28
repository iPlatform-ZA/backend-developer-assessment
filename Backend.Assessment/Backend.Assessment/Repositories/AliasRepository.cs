using Backend.Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Backend.Assessment.Context;

namespace Backend.Assessment.Repositories
{
    public class AliasRepository : Repository<Alias>, IAliasRepository
    {
        public BackendContext BackendContext
        {
            get { return Context as BackendContext; }
        }

        public AliasRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Alias> GetByArtistId(Guid artistId)
        {
            return BackendContext.Aliases.Where(a => a.ArtistId == artistId).ToList();
        }
    }
}
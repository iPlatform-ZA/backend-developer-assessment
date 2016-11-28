using Backend.Assessment.Models;
using System;
using System.Collections.Generic;

namespace Backend.Assessment.Repositories
{
    public interface IAliasRepository : IRepository<Alias>
    {
        IEnumerable<Alias> GetByArtistId(Guid artistId);
    }
}

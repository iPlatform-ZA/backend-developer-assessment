using Backend.Assessment.Context;
using Backend.Assessment.Models;
using System.Collections.Generic;

namespace Backend.Assessment.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        IEnumerable<Artist> SearchArtist(string criteria);
    }
}

using Backend.Assessment.Models;
using System;
using System.Collections.Generic;


namespace Backend.Assessment.Repositories
{
    public interface IAlbumRepository : IRepository<Album>
    {
        IEnumerable<Album> GetByArtistId(Guid artistId);
    }
}

using System;
using System.Collections.Generic;

using ArtistDAL.Models;

namespace ArtistService.Services
{
    public interface IArtistService :
        IDisposable
    {
        IEnumerable<Artist> GetAll();

        Artist Get(Guid id);
    }
}

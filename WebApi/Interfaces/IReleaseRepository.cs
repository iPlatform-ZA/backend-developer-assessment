using System;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IReleaseRepository
    {
        IEnumerable<Release> GetReleaseByArtistId(Guid id);

        IEnumerable<Release> GetAlbumsByArtistId(Guid id);
    }
}

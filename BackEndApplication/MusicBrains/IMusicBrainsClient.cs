using System;
using System.Collections.Generic;
namespace BackEndApplication.MusicBrains
{
    public interface IMusicBrainsClient
    {
        List<Release> GetAlbumsByArtistId(string artistId);
        List<Release> GetReleasesByArtistId(string artistId);
    }
}

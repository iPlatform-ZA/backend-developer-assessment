using Backend.Assessment.DTOs;
using System;

namespace Backend.Assessment.Services
{
    public interface IArtistService
    {
        ArtistResponse Search(string criteria, int pageNumber, int pageSize);

        AlbumResponse GetAlbumByArtist(Guid artistId);
    }
}

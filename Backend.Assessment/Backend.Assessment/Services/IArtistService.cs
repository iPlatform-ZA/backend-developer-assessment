using Backend.Assessment.DTOs;
using Backend.Assessment.Models;

namespace Backend.Assessment.Services
{
    public interface IArtistService
    {
        ArtistResponse Search(string criteria, int pageNumber, int pageSize);
    }
}

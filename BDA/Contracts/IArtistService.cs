using BDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDA.Contracts
{
    public interface IArtistService
    {
        ArtistResponseModel GetAll();

        ArtistResponseModel Search(string searchCriteria, string pageNumber, string pageSize);

        ReleaseResponseModel GetTopAlbums(string artistId);

        ReleaseResponseModel GetReleases(string artistId);



    }
}
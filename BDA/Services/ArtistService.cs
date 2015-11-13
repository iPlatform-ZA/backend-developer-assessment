using BDA.Contracts;
using BDA.Models;
using BDA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDA.Services
{
    public class ArtistService : IArtistService
    {
        private IArtistRepository artistRepo;

        public ArtistService()
        {
            artistRepo = new ArtistRepository();

        }
        public Models.ArtistResponseModel GetAll()
        {
            
            var result = new ArtistResponseModel();
            result.results = artistRepo.GetAll().ToList();
            result.page = 1;
            result.pageSize = 10;
            result.numberOfSearchResults = result.results.Count;
            result.numberOfPages = CalculatePages(result.numberOfSearchResults, result.pageSize);

            return result;

        }

        public Models.ArtistResponseModel Search(string searchCriteria, string pageNumber, string pageSize)
        {
           
            var result = new ArtistResponseModel();

            result.page = String.IsNullOrEmpty(pageNumber) ? 1 : Convert.ToInt16(pageNumber);
            result.pageSize = String.IsNullOrEmpty(pageSize) ? 10 : Convert.ToInt16(pageSize);

            result.results = artistRepo.Search(searchCriteria, result.page, result.pageSize).ToList();
            result.numberOfSearchResults = result.results.Count;
            result.numberOfPages = CalculatePages(result.numberOfSearchResults, result.pageSize);

            return result;
        }

        public ReleaseResponseModel GetTopAlbums(string artistId)
        {
            var releases = new ReleaseResponseModel()
            {
                Releases = MusicBrainzApi.GetMusicBrainz(artistId).Take(10).ToList()
            };
            return releases;
        }

        public ReleaseResponseModel GetReleases(string artistId)
        {
            var releases = new ReleaseResponseModel()
            {
                Releases = MusicBrainzApi.GetMusicBrainz(artistId)
            };
            return releases;
        }

        private int CalculatePages(int numResults, int pageSize)
        {
            if (pageSize == 0)
            {
                return 0;
            }

            double pages = (double)numResults / (double)pageSize;
            return (int)Math.Ceiling(pages);
        }


    }
}
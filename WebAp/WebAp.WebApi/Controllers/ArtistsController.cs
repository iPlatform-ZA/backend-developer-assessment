using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAp.Core.Dto;
using WebApCore.Entities;
using WebApCore.Interfaces;

namespace WebAp.WebApi.Controllers
{
    public class ArtistsController : ApiController

    {
        private IArtistRepository _artistrepo;
        private IQueryable<Artist> artistQuery;
        public ArtistsController(IArtistRepository artistrepo) //Injected the “IArtistRepository” inside “ArtistsController” constructor DI constructor pattern .
        {
            _artistrepo = artistrepo;

        }


        //* requirement 1 ```/artist/search/joh``` should return John Coltrane, John Mayer, Johnny Cash, Elton John and John Frusciante
        #region GetArtistsByName
        [HttpGet, ActionName("GetArtistsByName")]
        public Object search(string artistName)
        {
            artistQuery = _artistrepo.search(artistName).OrderBy(c => c.Name);
            var searchResults = artistQuery.ToList();
            var totalArtists = searchResults.Count();
            IList<ArtistDto> results = Mapper.Map<IList<Artist>, IList<ArtistDto>>(searchResults); // use automapper to map values to dto that we want  user to see

            return new
            {
                Results = results,
                numberOfSearchResults = totalArtists,



            };
        }
        #endregion


        // requirement 2 /artist/search/<search_criteria>/<page_number>/<page_size>``` as a GET. 
        #region GetArtistByPagination
        [HttpGet, ActionName("GetArtistByPagination")]
        public Object Get(string artistName, int pageNumber = 1, int pageSize = 10) // set page to default 1
        {

            artistQuery = _artistrepo.search(artistName).OrderBy(c => c.Name);

            var totalArtists = artistQuery.Count(); // gets the number of artists returned by the search
            var mod = totalArtists % pageSize; //retains the number of page left after taking chunk
            var pageCount = (totalArtists / pageSize) + (mod == 0 ? 0 : 1);// returns the number of pages that are returned if result is divided by pagesize

            var searchResults = artistQuery
            .Skip(pageSize * pageNumber)
            .Take(pageSize)
            .ToList();

            IList<ArtistDto> results = Mapper.Map<IList<Artist>, IList<ArtistDto>>(searchResults); // use automapper to map values to dto that we want  user to see

            return new
            {
                Results = results,
                numberOfSearchResults = totalArtists,
                page = pageNumber,
                pageSize = pageSize,
                numberOfPages = pageCount,


            };

        }
        #endregion


        // gets all artists
        #region GetAllArtists
        [HttpGet, ActionName("GetAllArtists")]
        public Object search()
        {
            artistQuery = _artistrepo.search().OrderBy(c => c.Name);
            var searchResults = artistQuery.ToList();
            var totalArtists = searchResults.Count();
            IList<ArtistDto> results = Mapper.Map<IList<Artist>, IList<ArtistDto>>(searchResults); // use automapper to map values to dto that we want  user to see

            return new
            {
                Results = results,
                numberOfSearchResults = totalArtists,
            };

        }
        #endregion




    }
}

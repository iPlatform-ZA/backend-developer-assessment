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
    public class ArtistsController : BaseApiController

    {
        private IQueryable<Artist> artistQuery;
    //Injected the “IArtistRepository” inside “ArtistsController” constructor DI constructor pattern .
        public ArtistsController(IArtistRepository artistrepo)
            : base(artistrepo)
        {
        }


        //* requirement 1 ```/artist/search/joh``` should return John Coltrane, John Mayer, Johnny Cash, Elton John and John Frusciante
        #region GetArtistsByName
        [HttpGet, ActionName("GetArtistsByName")]
        public Object search(string artistName)
        {
            artistQuery = ArtistDB.search(artistName).OrderBy(c => c.Name);
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
        public Object Get(string artistName, int pageNumber = 0 , int pageSize = 1) // set page to default 1
        {
            if (pageNumber <= 0)
            {
                pageNumber = 1; // this allows actual values to be retrieved at  actual values and prevents a negative skip amount 

            }
            artistQuery = ArtistDB.search(artistName).OrderBy(c => c.Name);
             
            var totalArtists = artistQuery.Count(); // gets the number of artists returned by the search
            var mod = totalArtists % pageSize; //retains the number of page left after taking chunk
            var pageCount = (totalArtists / pageSize) + (mod == 0 ? 0 : 1);// returns the number of pages that are returned if result is divided by pagesize
            var skipAmount = pageSize * (pageNumber - 1); // calculate actual number that has be skipped
                     var searchResults = artistQuery
                .Skip(skipAmount)
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
            artistQuery = ArtistDB.search().OrderBy(c => c.Name);
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

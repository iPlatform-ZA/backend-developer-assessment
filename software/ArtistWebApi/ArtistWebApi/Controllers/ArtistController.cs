using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ArtistWebApi.Models;
using ArtistWebApi.Models.BusinessObjects;
using ArtistWebApi.Models.Mapper;
using AttributeRouting.Web.Mvc;

namespace ArtistWebApi.Controllers
{
    public class ArtistController : ApiController
    {
        private ArtistWebApiContext dbContext = new ArtistWebApiContext();

        // GET api/Artist
        public IEnumerable<ArtistBO> Get()
        {
            var x = dbContext.Artists.AsEnumerable();
            return ArtistMapper.ConvertToArtistBOList(x);
        }


        /// <summary>
        /// Fetches an artist from the database.
        /// </summary>
        /// <param name="Id">Id of the artist</param>
        /// <returns>An artist</returns>
        public Artist Get(Guid Id)
        {
            return dbContext.Artists.Where(x => x.Id.CompareTo(Id) == 0).FirstOrDefault();
        }

        /// <summary>
        /// Searches for artists based on their names and aliases
        /// </summary>
        /// <param name="artistName">The name or alias of the artist. Part of name or alias is accepted </param>
        /// <param name="pageNumber">The specific page number to return</param>
        /// <param name="pageSize">The amount of data to return</param>
        /// <returns>A list of artists</returns>
        [ActionName("Search")]
        [AcceptVerbs("GET")]
        [Route("api/Artist/Search/artistName/{pageNumber:int}/{pageSize:int}")]
        public SearchResultsBO Search(string artistName, int pageNumber, int pageSize)
        {
            SearchResultsBO searchResults = new SearchResultsBO();
            if (!String.IsNullOrEmpty(artistName))
            {
                if ((pageNumber > 0) && (pageSize > 0))
                {
                    // find the artists 
                    var artistListFullResults = dbContext.Artists.Where(x => x.Name.ToUpper().Contains(artistName.ToUpper()) || x.Aliases.ToUpper().Contains(artistName.ToUpper())).OrderBy(x => x.Name);

                    // calculate offset based on pageNumber and pageSize
                    var calculatedOffset = (pageNumber - 1) * pageSize;
                    searchResults.NumberOfSearchResults = artistListFullResults.Count();
                    searchResults.NumberOfPages = (int)Math.Ceiling((double)searchResults.NumberOfSearchResults / pageSize);
                    searchResults.Page = pageNumber;
                    searchResults.PageSize = pageSize;

                    // Fetch the required pages
                    var artistList = artistListFullResults.Skip(calculatedOffset).Take(pageSize).ToList();

                    // convert to business object
                    searchResults.Results = ArtistMapper.ConvertToArtistBOList(artistList);
                }
            }

            return searchResults;
        }


        /// <summary>
        /// Fetches the releases of an artist from MusicBrainz, if the artist is present in the database.
        /// </summary>
        /// <param name="artistId">The artist's identifier</param>
        /// <returns>A list of releases for a particular artist</returns>
        [ActionName("Releases")]
        [AcceptVerbs("GET")]
        [Route("api/Artist/artistId/Releases")]
        public ReleasesBO Releases(Guid artistId)
        {
            ReleasesBO result = new ReleasesBO();

            var artist = Get(artistId);
            if (artist != null)
            {
                // Queries MusicBrainz to find the releases available for an artist
                var releases = MusicBrainz.Search.Release(arid: artist.Id.ToString());

                // convert to bussiness object
                result = ArtistMapper.ConvertToReleasesBO(releases.Data);
            }

            return result;
        }

        /// <summary>
        ///  Fetches the albums of an artist from MusicBrainz, if the artist is present in the database.
        /// </summary>
        /// <param name="artistIdentifier">The artist's identifier</param>
        /// <returns>Top 10 latest releases available for the artist</returns>
        [ActionName("Albums")]
        [AcceptVerbs("GET")]
        [Route("api/Artist/artistIdentifier/Albums")]
        public ReleasesBO Albums(Guid artistIdentifier)
        {
            ReleasesBO result = new ReleasesBO();
            var artist = Get(artistIdentifier);

            // Queries MusicBrainz to find the releases available for an artist
            var releases = MusicBrainz.Search.Release(arid: artist.Id.ToString());
            if ((releases.Data != null) && (releases.Data.Any()))
            {
                // top 10 latest releases
                var firstTenReleases = releases.Data.OrderByDescending(x => x.Date).Take(10).ToList();
                result = ArtistMapper.ConvertToReleasesBO(firstTenReleases);
            }
            return result;
        }

    

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}
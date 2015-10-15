using System;
using System.Collections.Generic;
using System.Linq;
using App.EntityFramework;
using App.EntityFramework.Domain;
using App.Services.Domain;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using MusicBrainzApi.Domain.Releases;
using MusicBrainzApi.Extensions;
using App.Services.Domain;


namespace App.Services.Services.Implementation
{
    public class Service : IService
    {
        /// <summary>
        /// Return the Artists Details
        /// </summary>
        /// <param name="criteria">Containing Search String</param>
        /// <param name="pageNumber">Specifc Page Number</param>
        /// <param name="pageSize">Page Size of Search Results</param>
        /// <returns>List of Artists</returns>
        public ArtistSearch GetArtists(string criteria, string pageNumber, string pageSize)
        {
            //Validate the input parameters
            int PageNumber; 
            int PageSize; 

            //Default Page Size and Page Number on invalid Parameters.
            if (int.TryParse(pageNumber, out PageNumber) == false) PageNumber = 1; // Default Page Number
            if (int.TryParse(pageSize, out PageSize) == false) PageSize = 10; // Default Page Size
            
            try
            {   
                var context = new Context();
                var artistsCount = context.Artists.Where(a => a.ArtistName.Contains(criteria)).Count();
                var artists = context.Artists.Where(a => a.ArtistName.Contains(criteria)).OrderBy(a => a.ArtistName).Skip((PageNumber - 1) * PageSize).Take(PageSize);
                return returnArtistSearchResult(artists, PageSize, PageNumber, artistsCount);
            }
            catch(Exception ex)
            {
                var error = ex;
                //Return Blank Object on Error that happens.
                return new ArtistSearch { numberOfPages = 0, numberOfSearchResults = 0, page = 0, pageSize = 0, results = null, IsSuccessful = false, Details = "An Error as Occurred Retrieving the Artist Information, Please contact the System Administrator" };
            }

        }

        /// <summary>
        /// Return the Artists Albums
        /// </summary>
        /// <param name="artistId">Artist Id</param>
        /// <returns>List of Artists Albums</returns>
        public ArtistAlbums GetArtistAlbums(string artistId)
        {
            try
            {
                var releases = RestExtensions.FetchReleases(Guid.Parse(artistId));
                
                ICollection<Release> returnReleases = new List<Release>();
                foreach (var item in releases.releaselist.release.Take(10))
                {
                    //Check for Artist Credit
                    var credits = new List<OtherArtists>();
                    foreach (var credit in item.artistcredit)
                    {
                        credits.Add(new OtherArtists
                        {
                            id = Guid.Parse(credit.artist.id),
                            name = credit.artist.name
                        });
                    }

                    //Add Releases to the Collection
                    returnReleases.Add
                    (
                        new Release
                        {
                            releaseId = Guid.Parse(item.id),
                            title = item.title,
                            status = item.status,
                            label = item.labelinfolist == null ? string.Empty : item.labelinfolist.labelinfo.label.name,
                            numberOfTracks = int.Parse(item.mediumlist.trackcount.ToString()),
                            otherArtists = credits.ToArray()
                        }
                    );
                }
                return new ArtistAlbums
                {
                    Releases = returnReleases,
                    IsSuccessful = true,
                    Details = "Artist Albums Retrieved Successfully."
                };
            }
            catch 
            {
                return new ArtistAlbums
                {
                    Releases = null,
                    IsSuccessful = false,
                    Details = "An Error as Occurred Retrieving the Artist Album Information, Please contact the System Administrator"
                };
            }
        }

        /// <summary>
        /// Return the Artists Releases
        /// </summary>
        /// <param name="artistId">Artist Id</param>
        /// <returns>List of the Artists Releases</returns>
        public ArtistReleases GetArtistReleases(string artistId)
        {
            try
            {
                return new ArtistReleases
                {
                    IsSuccessful = true,
                    Details = "Artist Releases Retrieved Successfully.",
                    Releases = RestExtensions.FetchReleases(Guid.Parse(artistId)).releaselist
                };
            }
            catch
            {
                return new ArtistReleases
                {
                    IsSuccessful = false,
                    Details = "An Error as Occurred Retrieving the Artist Releases Information, Please contact the System Administrator",
                    Releases = null
                };
            }
        }
        
        /// <summary>
        /// Format Collection of Artist into the Artist Search Response
        /// </summary>
        /// <param name="artists">Collection of Artists</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="artistsCount">Total Artist Count</param>
        /// <returns>Artist Search Response</returns>
        private ArtistSearch returnArtistSearchResult(IEnumerable<Artist> artists, int pageSize, int pageNumber, int artistsCount)
        {   
            //Calculate the number of pages
            int numberOfPages = artistsCount / pageSize;
            if (artistsCount % pageSize > 0)
                numberOfPages++;
            
            ICollection<Results> results = artists.Select(item => new Results {name = item.ArtistName, country = item.Country, aliases = item.Aliases.Split(',')}).ToList();
            return new ArtistSearch
            {   
                results = results,
                pageSize = pageSize,
                page = pageNumber,
                numberOfPages = numberOfPages,
                numberOfSearchResults = artistsCount,
                IsSuccessful = true,
                Details = "Artist Details Retrieved Successfully."
            };
        }
        

    }
}

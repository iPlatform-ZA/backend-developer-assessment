using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using App.Services.Domain;
using MusicBrainzApi.Domain.Releases;

namespace App.Services.Services
{
    [ServiceContract]
    public interface IService
    {   
        /// <summary>
        /// Return the Artists Details
        /// </summary>
        /// <param name="criteria">Containing Search String</param>
        /// <param name="pageNumber">Specifc Page Number</param>
        /// <param name="pageSize">Page Size of Search Results</param>
        /// <returns>List of Artists</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/artist/search/{criteria}/{pagenumber=1}/{pagesize=10}")]
        ArtistSearch GetArtists(string criteria, string pageNumber, string pageSize);

        /// <summary>
        /// Return the Artists Albums
        /// </summary>
        /// <param name="artistId">Artist Id</param>
        /// <returns>List of Artists Albums</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/artist/{artistid}/albums")]
        ArtistAlbums GetArtistAlbums(string artistId);

        /// <summary>
        /// Return the Artists Releases
        /// </summary>
        /// <param name="artistId">Artist Id</param>
        /// <returns>List of the Artists Releases</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/artist/{artistid}/releases")]
        ArtistReleases GetArtistReleases(string artistId);

        

    }
}

using Structure.Adapters.MusicBrainz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Adapters.MusicBrainz
{
    using Structure.Contracts.MusicBrainz;
    using System.Configuration;
    using System.Net;
    using System.IO;
    using Newtonsoft.Json;
    using Contracts;

    /// <summary>
    /// A music brainz adapter.
    /// </summary>
    public class MusicBrainzAdapter : IMusicBrainzAdapter
    {
        /// <summary>
        /// Gets the artist releases.
        /// </summary>
        /// <exception cref="Exception">Thrown when an exception error condition occurs.</exception>
        /// <param name="artistId">Identifier for the artist.</param>
        /// <param name="paging">The paging.</param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process the artist releases in this collection.
        /// </returns>
        public ReleasesResponse GetArtistReleases(Guid artistId, PagingArgs paging)
        {
            var baseUrl = ConfigurationManager.AppSettings["MusicBrainzUrl"];
            var version = ConfigurationManager.AppSettings["MusicBrainzVersion"];
            var appId = ConfigurationManager.AppSettings["ApplicationId"];
            var offset = paging.Page_Number;
            var limit = paging.Page_Size;
            var query = string.Format("?query=arid:{0}&offset={1}&limit={2}&fmt=json",artistId,offset,limit);
            var url = string.Format("{0}{1}/release/{2}", baseUrl, version, query);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.UserAgent = appId;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.StatusDescription);
                }

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var data = reader.ReadToEnd();
                    var serData = JsonConvert.DeserializeObject<ReleasesResponse>(data);
                    return serData;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BackEndApplication.Utils;
using BackEndApplication.WebClient;

namespace BackEndApplication.MusicBrains
{
    public class MusicBrainsClient : IMusicBrainsClient
    {
        private String serviceBaseURL = "http://musicbrainz.org/ws/2/";

        readonly IWebServiceClient webServiceClient;

        public MusicBrainsClient(IWebServiceClient webServiceClient)
        {
            this.webServiceClient = webServiceClient;
        }

        public List<Release> GetAlbumsByArtistId(String artistId)
        {
            string resourceFullURL = GetAlbumURL(artistId);

            Task<String> xmlResponseTask = webServiceClient.GetRequest(resourceFullURL);

            string xmlResponse = xmlResponseTask.Result;

            if (string.IsNullOrEmpty(xmlResponse)) throw new Exception("Error processing request.");

            return ReleaseProcessor.GetList(xmlResponse, artistId);
        }

        public List<Release> GetReleasesByArtistId(String artistId)
        {
            string resourceFullURL = GetReleaseURL(artistId);

            Task<String> xmlResponseTask = webServiceClient.GetRequest(resourceFullURL);

            string xmlResponse = xmlResponseTask.Result;

            return ReleaseProcessor.GetList(xmlResponse, artistId);
        }

        private string GetAlbumURL(String artistId)
        {
            String resourceUrl = String.Format("release/?query=arid:{0}&primarytype:album&limit=10&offset=0", artistId);

            String resourceFullURL = String.Format("{0}{1}", serviceBaseURL, resourceUrl);

            return resourceFullURL;
        }

        private string GetReleaseURL(String artistId)
        {
            String resourceUrl = String.Format("release/?query=arid:{0}&limit=10&offset=0", artistId);

            String resourceFullURL = String.Format("{0}{1}", serviceBaseURL, resourceUrl);

            return resourceFullURL;
        }
    }
}
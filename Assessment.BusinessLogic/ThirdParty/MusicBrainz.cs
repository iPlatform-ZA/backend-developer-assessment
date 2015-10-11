using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;

using Assessment.Models.ThirdParty.MusicBrainz;

namespace Assessment.BusinessLogic.Common
{
    internal static class MusicBrainz
    {
        internal static string requestUri = string.Empty;
        internal static string requestAPIPath = string.Empty;
        internal static string requestFull = string.Empty;

        static MusicBrainz()
        {
            requestUri = ConfigurationManager.AppSettings["MusicBrainzURI"].ToString();
            requestAPIPath = ConfigurationManager.AppSettings["MusicBrainzAPIPath"].ToString();
        }

        internal static async Task<MBArtistReleaseDTO> GetArtistsReleases(string id)
        {
            //Sample Uri: http://musicbrainz.org/ws/2/artist/65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab?inc=releases&fmt=json

            MBArtistReleaseDTO artistReleases = new MBArtistReleaseDTO();
            string requestFull = string.Empty;

            try
            {
                string requestAPI = ConfigurationManager.AppSettings["MusicBrainzArtistAPI"].ToString();
                string requestArguments = ConfigurationManager.AppSettings["MusicBrainzArtistArguments"].ToString();
                string request = requestAPIPath + requestAPI + id + "?inc=" + requestArguments + "&fmt=json";

                requestFull = requestUri + request;

                artistReleases = await HttpHelper<MBArtistReleaseDTO>.Request(requestUri, request);
            }
            catch (Exception ex)
            {
                artistReleases = new MBArtistReleaseDTO();
                Logger.LogEvent(requestFull + "\r\n" + ex.ToString());
            }

            return artistReleases;
        }

        internal static async Task<MBArtistReleaseDTO> GetArtistsReleases(string id, int offset, int limit)
        {
            //Sample Uri: http://musicbrainz.org/ws/2/artist/65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab?inc=releases&fmt=json

            MBArtistReleaseDTO artistReleases = new MBArtistReleaseDTO();
            string requestFull = string.Empty;

            try
            {
                string requestAPI = ConfigurationManager.AppSettings["MusicBrainzArtistAPI"].ToString();
                string requestArguments = ConfigurationManager.AppSettings["MusicBrainzArtistArguments"].ToString();
                string request = requestAPIPath + requestAPI + id + "?inc=" + requestArguments + "&offset=" + offset + "&limit=" + limit + "&fmt=json";

                requestFull = requestUri + request;

                artistReleases = await HttpHelper<MBArtistReleaseDTO>.Request(requestUri, request);
            }
            catch (Exception ex)
            {
                artistReleases = new MBArtistReleaseDTO();
                Logger.LogEvent(requestFull + "\r\n" + ex.ToString());
            }

            return artistReleases;
        }

        internal static async Task<MBReleaseInfoDTO> GetReleaseInfo(string id)
        {
            //Sample URI: http://musicbrainz.org/ws/2/release/0af02a32-7deb-3ff0-bbe8-f23a4227494f?inc=labels+media+artist-credits&fmt=json

            MBReleaseInfoDTO artistInfo = new MBReleaseInfoDTO();

            try
            {
                string requestAPI = ConfigurationManager.AppSettings["MusicBrainzReleaseAPI"].ToString();
                string requestArguments = ConfigurationManager.AppSettings["MusicBrainzReleaseArguments"].ToString();
                string request = requestAPIPath + requestAPI + id + "?inc=" + requestArguments + "&fmt=json";

                requestFull = requestUri + request;

                artistInfo = await HttpHelper<MBReleaseInfoDTO>.Request(requestUri, request);
            }
            catch (Exception ex)
            {
                artistInfo = new MBReleaseInfoDTO();
                Logger.LogEvent(requestFull + "\r\n" + ex.ToString());
            }

            return artistInfo;
        }

        internal static async Task<MBReleaseInfoDTO> GetReleaseInfo(string id, int offset, int limit)
        {
            //Sample URI: http://musicbrainz.org/ws/2/release/0af02a32-7deb-3ff0-bbe8-f23a4227494f?inc=labels+media+artist-credits&fmt=json

            MBReleaseInfoDTO artistInfo = new MBReleaseInfoDTO();

            try
            {
                string requestAPI = ConfigurationManager.AppSettings["MusicBrainzReleaseAPI"].ToString();
                string requestArguments = ConfigurationManager.AppSettings["MusicBrainzReleaseArguments"].ToString();
                string request = requestAPIPath + requestAPI + id + "?inc=" + requestArguments + "&offset=" + offset + "&limit=" + limit + "&fmt=json";

                requestFull = requestUri + request;

                artistInfo = await HttpHelper<MBReleaseInfoDTO>.Request(requestUri, request);
            }
            catch (Exception ex)
            {
                artistInfo = new MBReleaseInfoDTO();
                Logger.LogEvent(requestFull + "\r\n" + ex.ToString());
            }

            return artistInfo;
        }
    }
}

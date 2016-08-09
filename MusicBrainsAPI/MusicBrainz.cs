using MusicBrainsAPI.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicBrainsAPI
{
    /// <summary>
    /// This class is a basic wrapper for the MusicBrainz Search API documented at http://musicbrainz.org/doc/Development/XML_Web_Service/Version_2/Search
    /// as on 7 August 2016.
    /// A configuration value named MusicBrainzRetryAttempts can be set to an integer value to control how many time a call to the MusicBraiz service
    /// should be made in case the service repsonds with 503 - Service Unavailable.
    /// </summary>
    public class MusicBrainz
    {
        private static string _musicBrainzApiBaseUrl = "http://musicbrainz.org/ws/2/{0}/?query={1}&limit={2}&offset={3}";

        /// <summary>
        /// Gets all the releases by the specified artist.
        /// </summary>
        /// <param name="artistId">The unique MusicBrainz artist ID</param>        
        public static SearchResponse<Release> GetReleasesByArtistId(Guid artistId)
        {
            SearchResponse<Release> returnValue = new SearchResponse<Release>();

            KeyValuePair<string, string>[] artistIdKeyValuePairs = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("arid", artistId.ToString())
            };

            string query = BuildQueryParamForSearch("OR", artistIdKeyValuePairs);
            string url = BuildUrl(SearchableEntiesEnum.Release, query, 100, 0);

            string stringResponse = null;

            try
            {
                stringResponse = HttpCallProcessor.Request(url);
                
                SearchReleaseResponse response = DeserializeSearchResponse<SearchReleaseResponse>(stringResponse);

                if (response.ReleaseList == null || response.ReleaseList.Releases == null)
                {
                    returnValue.Result = new Release[0];
                }
                else
                {
                    returnValue.Result = response.ReleaseList.Releases;
                }

                returnValue.Success = true;
                returnValue.Error = null;
            }
            catch (System.Net.WebException webEx)
            {
                returnValue.Success = false;
                returnValue.Error = $"The call to the MusicBrainz service failed with status {(int)webEx.Status} - {webEx.Status}";
            }
            catch (Exception ex)
            {
                returnValue.Success = false;
                returnValue.Error = ex.Message;
            }

            return returnValue;
        }
        
        public static SearchResponse<Release> GetReleasesByReleaseId(params Guid[] releaseId)
        {
            SearchResponse<Release> returnValue = new SearchResponse<Release>();

            List<KeyValuePair<string, string>> releaseIdKeyValuePairs = new List<KeyValuePair<string, string>>();

            foreach(Guid id in releaseId)
            {
                releaseIdKeyValuePairs.Add(new KeyValuePair<string, string>("reid", id.ToString()));
            };

            string query = BuildQueryParamForSearch("OR", releaseIdKeyValuePairs.ToArray());
            string url = BuildUrl(SearchableEntiesEnum.Release, query, 100, 0);

            string stringResponse = null;

            try
            {
                stringResponse = HttpCallProcessor.Request(url);

                SearchReleaseResponse response = DeserializeSearchResponse<SearchReleaseResponse>(stringResponse);

                returnValue.Result = response.ReleaseList.Releases ?? new Release[0];
                returnValue.Success = true;
                returnValue.Error = null;
            }
            catch (System.Net.WebException webEx)
            {
                returnValue.Success = false;
                returnValue.Error = $"The call to the MusicBrainz service failed with status {(int)webEx.Status} - {webEx.Status}";
            }
            catch (Exception ex)
            {
                returnValue.Success = false;
                returnValue.Error = ex.Message;
            }

            return returnValue;
        }

        public static SearchResponse<ReleaseGroup> GetReleaseGroupsByArtistId(Guid artistId)
        {
            SearchResponse<ReleaseGroup> returnValue = new SearchResponse<ReleaseGroup>();

            KeyValuePair<string, string>[] artistIdKeyValuePairs = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("arid", artistId.ToString())
            };

            string query = BuildQueryParamForSearch("OR", new KeyValuePair<string, string>("arid", artistId.ToString()));
            string url = BuildUrl(SearchableEntiesEnum.ReleaseGroup, query, 100, 0);

            string stringResponse = null;

            try
            {
                stringResponse = HttpCallProcessor.Request(url);

                SearchReleaseGroupResponse response = DeserializeSearchResponse<SearchReleaseGroupResponse>(stringResponse);

                if (response.ReleaseGoupList == null || response.ReleaseGoupList.ReleaseGroups == null)
                {
                    returnValue.Result = new ReleaseGroup[0];
                }
                else
                {
                    returnValue.Result = response.ReleaseGoupList.ReleaseGroups ?? new ReleaseGroup[0];
                }

                returnValue.Success = true;
                returnValue.Error = null;
            }
            catch (System.Net.WebException webEx)
            {
                returnValue.Success = false;
                returnValue.Error = $"The call to the MusicBrainz service failed with status {(int)webEx.Status} - {webEx.Status}";
            }
            catch (Exception ex)
            {
                returnValue.Success = false;
                returnValue.Error = ex.Message;
            }

            return returnValue;

            return null;
        }


        /// <summary>
        /// Desirializes the XML string returned from the MusicBrainz servive into the specified class
        /// </summary>
        /// <typeparam name="T">The type of response to deserialze to</typeparam>
        /// <param name="stringResponse">The response from the MusicBrainz servive</param>
        /// <returns>T</returns>
        private static T DeserializeSearchResponse<T>(string stringResponse) where T : class
        {
            try
            {
                return XmlDeserializer.Deserialize<T>(stringResponse);
            }
            catch (Exception ex)
            {
                throw new Exception($"The response from the MusicBrainz service could not be parsed.\nResponse:\n{stringResponse}", ex);
            }
        }

        /// <summary>
        /// Generates the complete URL that is used to search the MuisicBrainz service.
        /// </summary>
        /// <param name="searchType">The resource to search.</param>
        /// <param name="query">The query on the resource.</param>
        /// <param name="limit">The number of results to limit the response to. Must be between 1 and 100. Out of bounds values are forced into bounds.</param>
        /// <param name="offset">0 based. Used for paging in conjunction with the limit. Out of bounds values are forced into bounds.</param>
        /// <returns></returns>
        private static string BuildUrl(SearchableEntiesEnum searchType, string query, int limit, int offset)
        {
            // force the limit to a value between 1 and 100
            limit = Math.Abs(limit) % 100;

            if (limit == 0)
            {
                limit = 100;
            }

            // force the offset to a positve value
            offset = Math.Abs(offset);

            return string.Format(_musicBrainzApiBaseUrl, TranslateSearchableEntitiesEnum(searchType), query, limit, offset);
        }

        private static string BuildQueryParamForSearch(string opperator, params KeyValuePair<string, string>[] queryParameters)
        {
            IEnumerable<string> concatenatedKeyValuePairs = queryParameters
                .Where(i => !string.IsNullOrWhiteSpace(i.Key) && !string.IsNullOrWhiteSpace(i.Value))
                .Select(i => string.Format("{0}:{1}", i.Key, i.Value));

            return string.Join($" {opperator} ", concatenatedKeyValuePairs);
        }

        private static string TranslateSearchableEntitiesEnum(SearchableEntiesEnum searchableEntity)
        {
            switch (searchableEntity)
            {
                case SearchableEntiesEnum.Annotation:
                    return "annotation";
                case SearchableEntiesEnum.Area:
                    return "area";
                case SearchableEntiesEnum.Artist:
                    return "artist";
                case SearchableEntiesEnum.CDStubs:
                    return "cdstubs";
                case SearchableEntiesEnum.FreeDb:
                    return "freedb";
                case SearchableEntiesEnum.Label:
                    return "label";
                case SearchableEntiesEnum.Place:
                    return "place";
                case SearchableEntiesEnum.Recording:
                    return "recording";
                case SearchableEntiesEnum.Release:
                    return "release";
                case SearchableEntiesEnum.ReleaseGroup:
                    return "release-group";
                case SearchableEntiesEnum.Tag:
                    return "tag";
                case SearchableEntiesEnum.Work:
                    return "work";
                default:
                    return "";
            }
        }
    }
}

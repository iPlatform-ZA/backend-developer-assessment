using BDA.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace BDA
{
    public static class MusicBrainzApi
    {
        public static List<ReleaseModel> GetMusicBrainz(string artistId)
        {
            var url = "http://musicbrainz.org/ws/2/release/?query=arid:" + artistId + "&fmt=json";
            var syncClient = new WebClient();
            var content = syncClient.DownloadString(url);

            string res;

            res = content;
            dynamic dyn = JsonConvert.DeserializeObject(res);

            var lstReleaseObjects = new List<ReleaseModel>();
            
            foreach (var obj in dyn.releases)
            {
                try
                {
                    var releaseItem = new ReleaseModel()
                    {
                        NumberOfTracks = ParseValue(obj["track-count"]),
                        ReleaseId = ParseValue(obj.id),
                        Status = ParseValue(obj.status),
                        Title = ParseValue(obj.title)
                    };

                    if (obj["label-info"] != null)
                    {
                        releaseItem.Label = ParseValue(obj["label-info"].First.label.name);
                    }
                    else
                    {
                        releaseItem.Label = "";
                    }

                    if (obj["artist-credit"] != null)
                    {
                        foreach (var ac in obj["artist-credit"])
                        {
                            releaseItem.OtherArtists.Add(new OtherArtistModel()
                            {
                                Id = ParseValue(ac.artist.id),
                                Name = ParseValue(ac.artist.name)
                            });
                        }
                    }

                    lstReleaseObjects.Add(releaseItem);
                }
                catch (Exception e)
                {
                    throw e;
                   
                }

            } //end foreach
            return lstReleaseObjects;
        }


        private static string ParseValue(dynamic obj)
        {
            try
            {
                if (obj != null)
                {
                    return obj.ToString();
                }

            }
            catch
            {

                return "";
            }
            return "";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassLib.Abstract;
using ClassLib.Data;
using ClassLib.Factories;
using ClassLib.interfaces;
using ClassLib.Models;

namespace ClassLib.Helpers
{
    public static class APIHelper
    {
        public static List<ArtistModel> SearchForArtist(string artist)
        {
            List<ArtistModel> artists = new List<ArtistModel>();
            try
            {
                ArtistsFactory<IArtist, ArtistModel> artFact = new ArtistsFactory<IArtist, ArtistModel>();
                using (ArtistsEntities artistsEntities = new ArtistsEntities())
                {
                    if (artistsEntities.Artists.Any(x => x.ArtistsName.Contains(artist)))
                    {
                        foreach (var source in artistsEntities.Artists.Where(x => x.ArtistsName.Contains(artist)))
                        {
                            artists.Add(artFact.GetObject(source));
                        }
                    }
                }
                return artists;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        public static List<ReleaseResult> GetReleases(string artistId)
        {
            try
            {
                List<ReleaseResult> releases = new List<ReleaseResult>();
                WebClient client = new WebClient();
                ArtistsFactory<IReleaseResult, ReleaseResult> releaseFact = new ArtistsFactory<IReleaseResult, ReleaseResult>();
                client.UseDefaultCredentials = true;
                client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36");
                var str = client.OpenRead(new Uri("http://musicbrainz.org/ws/2/release/?query=arid:" + artistId.ToLower()));
                XDocument xdoc = XDocument.Load(str);
                var releaseList = xdoc.Root.Descendants().Where(x => x.Name.LocalName == "release-list");
                foreach (var xElement in releaseList)
                {
                    var newReleases = xElement.Descendants().Where(x => x.Name.LocalName == "release");

                    foreach (var newRelease in newReleases)
                    {
                        releases.Add(releaseFact.GetObject(newRelease));
                    }
                }
                return releases;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
           
        }
    }
}

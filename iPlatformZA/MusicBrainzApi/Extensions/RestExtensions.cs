using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

namespace MusicBrainzApi.Extensions
{
    public static class RestExtensions
    {
        const string releaseUrl = " http://musicbrainz.org/ws/2/release/?query=arid:";
        public static Domain.Releases.metadata FetchReleases(Guid artistId)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(releaseUrl + artistId) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());

                XmlSerializer serializer = new XmlSerializer(typeof(MusicBrainzApi.Domain.Releases.metadata));
                MusicBrainzApi.Domain.Releases.metadata releases;
                using (StringReader reader = new StringReader(xmlDoc.InnerXml))
                {
                    releases = (MusicBrainzApi.Domain.Releases.metadata)(serializer.Deserialize(reader));
                }
                return releases;
            }
            catch (Exception ex)
            {
                var error = ex;
                return null;
            }
            
        }
                       
    }
}

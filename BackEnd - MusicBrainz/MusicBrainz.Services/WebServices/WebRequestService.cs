using MusicBrainz.Platform.Domain.MusicBrainz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MusicBrainz.Services.WebServices
{
    public class WebRequestService : IWebRequestService
    {
        public XElement Get(string artistId)
        {
            try
            {
                var url = $"https://musicbrainz.org/ws/2/release?artist={artistId}&limit=10&include=all";
                url = $"http://musicbrainz.org/ws/2/release?query=arid:{artistId}&fmt=xml&include=all&limit=10&offset=0";
                var request = WebRequest.Create(url) as HttpWebRequest;
                if (request == null)
                    return new XElement("");

                request.UserAgent = "StructItMusicBrainz.API/2.0";
                request.Proxy = WebRequest.DefaultWebProxy;
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Proxy.Credentials = CredentialCache.DefaultCredentials;
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                var response = request.GetResponse();

                using (var stream = response.GetResponseStream())
                {
                    var xml = XDocument.Load(stream);
                    var xsn = new XmlSerializerNamespaces();
                    xsn.Add("ext", "http://musicbrainz.org/ns/ext#-2.0");
                    return xml.Root != null ? xml.Root.Elements().FirstOrDefault() : new XElement("");
                }
            }
            catch (Exception ex)
            {
                return new XElement("");
            }
        }

        public Release GetReleases(string artistId)
        {
            
            var serializer = new XmlSerializer(typeof(Release));

            try
            {
                var release = Get(artistId);
                {
                    return (Release)serializer.Deserialize(release.CreateReader());
                }
            }
            catch (Exception)
            {
                return default(Release);
            }
        }
    }
}

using DAL.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

using System.Xml;
using System.Xml.Linq;

using Newtonsoft.Json;
using DAL.MusicBrainzJsonModel;

namespace DAL
{
    public static class MusicBrainzClient
    {

        public static List<Album> GetReleases(string query, string type = "artist")
        {
            var res = new List<Album>();

            string url = $"http://musicbrainz.org/ws/2/release/?query=arid:{query}&primarytype:album&limit=10&fmt=json";
            var jsonString = "{}";


            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
           
            

            /*

            var client = new RestClient($"http://musicbrainz.org/ws/2/release/?query=arid:{query}&limit=10");
            var request = new RestRequest(Method.GET);            
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            var xdoc = XDocument.Load(response.Content.ToString());

            IEnumerable<XElement> xe = xdoc.Root.Elements("release");

            var items = from  a in xdoc.Root.Elements("release")                        
                        select a.Attribute("count"); 
            */

            try
            {
                //jsonString = new WebClient()..DownloadString(url);

                IRestResponse response = client.Execute(request);              

                jsonString =response.Content;

                Rootobject data = JsonConvert.DeserializeObject<Rootobject>(jsonString);

                foreach( var r in data.releases)
                {
                    res.Add(new Album
                    {
                        releaseId = r.id,
                        title = r.title,
                        status = r.status,
                        numberOfTracks = r.trackcount,
                        label = (r.labelinfo != null) ? r.labelinfo.FirstOrDefault().label.name : "",
                        otherArtist = new List<OtherArtist>()
                        
                    });
                   
                    
                }

            }
            catch(Exception e)
            {
                return res;
            }
            

            




            return res;
        }
    }
    
}

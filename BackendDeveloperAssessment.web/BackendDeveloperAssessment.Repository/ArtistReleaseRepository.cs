using BackendDeveloperAssessment.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperAssessment.Repository
{
    public class ArtistReleaseRepository //: IArtistReleaseRepository
    {
        public void Test()
        {

            using (var client = new HttpClient(new HttpClientHandler()))
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml,application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");

                HttpResponseMessage response = client.GetAsync("http://musicbrainz.org/ws/2/release/?query=arid:65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab&fmt=json").Result;
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStringAsync().Result;

            }
        }
    }
}

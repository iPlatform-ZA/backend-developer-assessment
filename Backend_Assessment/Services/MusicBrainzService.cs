using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using System.Threading.Tasks;

namespace Backend_Assessment.Services
{
    public class MusicBrainzService
    {
        private const string baseUrl = "http://musicbrainz.org/ws/2/";
        private readonly RestClient _client;

        public MusicBrainzService()
        {
            _client = new RestClient(baseUrl);
        }


        public IQueryable<EntityModels.Release> GetReleases(string artistId)
        {
            var result = _client.Execute<List<EntityModels.Release>>(new RestRequest($"release/?query=arid:{artistId}&limit=100", Method.GET) { RequestFormat = DataFormat.Xml });

            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return result.Data.Select(x =>
                {
                    x.NameCredit = x.NameCredit.Where(nc => nc.Id != artistId).ToList();
                    return x;
                }).AsQueryable();
            }

            throw result.ErrorException;
        }
    }
}
﻿using System;
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


        public IQueryable<EntityModels.Release> GetReleases(string artistId, int limit = 100, bool albumOnly = false)
        {
            var result = _client.Execute<List<EntityModels.Release>>(new RestRequest($"release/?query=arid:{artistId}&limit={limit}{(albumOnly ? "&type=album" : "")}", Method.GET) { RequestFormat = DataFormat.Xml });

            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return result.Data.AsQueryable();
            }

            throw result.ErrorException;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using ClassLib.Data;
using ClassLib.Factories;
using ClassLib.Helpers;
using ClassLib.interfaces;
using ClassLib.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Xml.XPath;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ArtistsFactory<IArtist,ArtistModel> fact = new ArtistsFactory<IArtist, ArtistModel>();

            ArtistsEntities artEntities = new ArtistsEntities();
            List<ArtistModel> artists = new List<ArtistModel>();

            foreach (var artist in artEntities.Artists)
            {
                artists.Add(fact.GetObject(artist));
            }
        }

        [TestMethod]
        public void SearchArtistTest()
        {
            var result = APIHelper.SearchForArtist("John");
        }

        [TestMethod]
        public void SearchArtistJsonResultsTest()
        {
            SearchResults result = new SearchResults("joh","4","3");
            var jsonResult = JsonConvert.SerializeObject(result);
        }

        [TestMethod]
        public void GetReleaseDataTest()
        {
            string artistid = "65F4F0C5-EF9E-490C-AEE3-909E7AE6B2AB";
            var results = APIHelper.GetReleases(artistid);

            //WebClient client = new WebClient();
            //client.UseDefaultCredentials = true;
            //client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36");
            //var str = client.OpenRead(new Uri("http://musicbrainz.org/ws/2/release/?query=arid:" + artistid.ToLower()));
            //XDocument xdoc = XDocument.Load(str);
            //var releases = xdoc.Root.Descendants().Where(x => x.Name.LocalName == "release-list");
            //foreach (var xElement in releases)
            //{
            //    var newReleases = xElement.Descendants().Where(x=>x.Name.LocalName == "release");
            //}

        }
    }
}

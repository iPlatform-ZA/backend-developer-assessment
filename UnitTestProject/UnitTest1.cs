using System;
using System.Collections.Generic;
using ClassLib.Data;
using ClassLib.Factories;
using ClassLib.Helpers;
using ClassLib.interfaces;
using ClassLib.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

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
    }
}

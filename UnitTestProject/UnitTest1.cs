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
            var success = true;
            ArtistsFactory<IArtist,ArtistModel> fact = new ArtistsFactory<IArtist, ArtistModel>();

            ArtistsEntities artEntities = new ArtistsEntities();
            List<ArtistModel> artists = new List<ArtistModel>();

            foreach (var artist in artEntities.Artists)
            {
                artists.Add(fact.GetObject(artist));
            }

            if (artists.Count < 15)
            {
                success = false;
            }

            if (success == false)
            {
                Assert.Fail("Not all artists has been created by factory! Expecting 15");
            }
        }

        [TestMethod]
        public void SearchArtistTest()
        {
            var result = APIHelper.SearchForArtist("Metal");
            if (result.Count != 1)
            {
                Assert.Fail("Expecting only one result.");
            }
            else
            {
                if (!result.Any(x => x.ArtistsName == "Metallica"))
                {
                    Assert.Fail("Expecting Metallica to be returned");
                }
            }
            
        }

        [TestMethod]
        public void SearchArtistJsonResultsTest()
        {
            string resultToCompare = "{\"Results\":[{\"UniqueId\":\"6456a893-c1e9-4e3d-86f7-0008b0a3ac8a\",\"ArtistsName\":\"Jack Johnson\",\"Country\":\"US\",\"Aliases\":[\"Jack Hody Johnson\"]},{\"UniqueId\":\"144ef525-85e9-40c3-8335-02c32d0861f3\",\"ArtistsName\":\"John Mayer\",\"Country\":\"US\",\"Aliases\":[]},{\"UniqueId\":\"18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f\",\"ArtistsName\":\"Johnny Cash\",\"Country\":\"US\",\"Aliases\":[\"Johhny Cash\",\"Jonny Cash\"]},{\"UniqueId\":\"b625448e-bf4a-41c3-a421-72ad46cdb831\",\"ArtistsName\":\"John Coltrane\",\"Country\":\"US\",\"Aliases\":[\"John Coltraine\",\"John William Coltrane\"]},{\"UniqueId\":\"b83bc61f-8451-4a5d-8b8e-7e9ed295e822\",\"ArtistsName\":\"Elton John\",\"Country\":\"GB\",\"Aliases\":[\"E. John\",\" Elthon John\",\"Elton Jphn\",\"John Elton\",\" Reginald Kenneth Dwight\"]},{\"UniqueId\":\"f1571db1-c672-4a54-a2cf-aaa329f26f0b\",\"ArtistsName\":\"John Frusciante\",\"Country\":\"US\",\"Aliases\":[\"John Anthony Frusciante\"]}],\"NumberOfSearchResults\":\"6\",\"Page\":\"4\",\"PageSize\":\"3\",\"NumberOfPages\":\"2\"}";
            SearchResults result = new SearchResults("joh","4","3");
            var jsonResult = JsonConvert.SerializeObject(result);

            if (jsonResult != resultToCompare)
            {
                Assert.Fail("Json string returned not correct. Expecting:" + resultToCompare + " Returned:" + jsonResult);
            }
        }

        [TestMethod]
        public void GetReleaseDataTest()
        {
            string expectedResult = "[{\"ReleaseId\":\"89af5e61-84d9-4b93-8ab7-b1a2b034a79e\",\"Title\":\"Dharohar Project, Laura Marling and Mumford & Sons\",\"Status\":\"Official\",\"Label\":\"Universal Island Records\",\"NumberOfTracks\":\"4\",\"OtherArtists\":[{\"Id\":\"a015074b-e109-412d-9f7b-170b80a0ebbd\",\"name\":\"Dharohar Project\"},{\"Id\":\"cd9713d6-6e5f-4143-9412-4d12b7bd47f2\",\"name\":\"Laura Marling\"},{\"Id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford & Sons\"}]},{\"ReleaseId\":\"03afc9df-085b-41c3-9bc8-737f01ea4edf\",\"Title\":\"Dharohar Project, Laura Marling and Mumford & Sons\",\"Status\":\"Official\",\"Label\":\"Glassnote\",\"NumberOfTracks\":\"4\",\"OtherArtists\":[{\"Id\":\"a015074b-e109-412d-9f7b-170b80a0ebbd\",\"name\":\"Dharohar Project\"},{\"Id\":\"cd9713d6-6e5f-4143-9412-4d12b7bd47f2\",\"name\":\"Laura Marling\"},{\"Id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford & Sons\"}]},{\"ReleaseId\":\"4cf8c4b7-2471-46cd-8865-f2a744f26e8d\",\"Title\":\"Dharohar Project, Laura Marling and Mumford & Sons\",\"Status\":\"Official\",\"Label\":\"Glassnote\",\"NumberOfTracks\":\"4\",\"OtherArtists\":[{\"Id\":\"a015074b-e109-412d-9f7b-170b80a0ebbd\",\"name\":\"Dharohar Project\"},{\"Id\":\"cd9713d6-6e5f-4143-9412-4d12b7bd47f2\",\"name\":\"Laura Marling\"},{\"Id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford & Sons\"}]},{\"ReleaseId\":\"9cc88413-d456-4b96-a0c1-09fa6cc2cf88\",\"Title\":\"iTunes Festival: London 2010\",\"Status\":\"Official\",\"Label\":\"Gentlemen of the Road\",\"NumberOfTracks\":\"8\",\"OtherArtists\":[{\"Id\":\"a015074b-e109-412d-9f7b-170b80a0ebbd\",\"name\":\"Dharohar Project\"},{\"Id\":\"cd9713d6-6e5f-4143-9412-4d12b7bd47f2\",\"name\":\"Laura Marling\"},{\"Id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford & Sons\"}]}]";
            
            string artistid = "a015074b-e109-412d-9f7b-170b80a0ebbd";
            var results = APIHelper.GetReleases(artistid);
            var jsonResult = JsonConvert.SerializeObject(results);

            Assert.AreEqual(expectedResult,jsonResult);
        }
    }
}

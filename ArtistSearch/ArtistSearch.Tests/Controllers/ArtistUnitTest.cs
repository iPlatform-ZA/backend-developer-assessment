using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtistSearch.Controllers;
using System.Threading.Tasks;
using ArtistSearch.Models;
using ArtistSearch.Helpers;

namespace ArtistSearch.Tests.Controllers
{
    /// <summary>
    /// Test Artist Control Index and search
    /// </summary>
    [TestClass]
    public class ArtistUnitTest
    {
        public static ArtistController ac;
        [TestMethod]
        public void Search()
        {
            ac = new ArtistController();

            Task<ReleaseMetadata> a = ac.GetSearch("c44e9c22-ef82-4a77-9bcd-af6c958446d6");
            a.Wait();
            // Assert
            Assert.IsNotNull(a.Result);
        }

        [TestMethod]
        public void GetArtist()
        {
            ac = new ArtistController();

            ArtistDetails a = ac.GetArtist("joh", 0, 10);

            // Assert
            Assert.IsNotNull(a);
        }
    }
}

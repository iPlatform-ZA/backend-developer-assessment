using Backend.Assessment.Controllers;
using Backend.Assessment.Services;

using System.Net.Http;

using Moq;

using NUnit.Framework;
using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using System.Web.Routing;
using System.Web;
using System.Web.Mvc;

namespace Backend.Assessment.Tests.Controllers
{

    [TestFixture]
    public class ArtistControllerTest
    {
        private IArtistService ArtistService { get; set; }
        private ArtistController Controller { get; set; }
        public ArtistControllerTest()
        {
            ArtistService = new Mock<IArtistService>().Object;
            Controller = new ArtistController(ArtistService);
        }

        [Test]
        [TestCase("55c6eb6e-8388-497c-acaf-dbff584d0c3a", HttpStatusCode.OK)]
        public void GetAlbumsByArtist(string artistId, HttpStatusCode result )
        {
            HttpResponseMessage message = Controller.GetAlbumsByArtist(new Guid(artistId));

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(message.StatusCode, result);
        }


    }
}

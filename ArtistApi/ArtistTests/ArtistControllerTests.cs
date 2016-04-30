using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using NUnit.Framework;

using Moq;

using ArtistApi.Controllers;
using ArtistDAL.Models;
using ArtistService.Services;

namespace ArtistTests
{
    [TestFixture]
    public class ArtistControllerTests
    {
        [Test]
        public void GetArtists_ShouldReturnAllArtists()
        {
            // arrange
            var expected = new Artist[] { new Artist { Id = Guid.NewGuid() };

            var service = new Mock<IArtistService>();

            service.Setup(s => s.GetAll())
                   .Returns(expected);

            var controller = new ArtistController(service.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // act
            var response = controller.GetArtists();

            IEnumerable<Artist> actual;
            response.TryGetContentValue(out actual);

            // assert
            Assert.That(response.StatusCode == HttpStatusCode.OK);

            CollectionAssert.IsNotEmpty(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetArtist_WithValidId_ShouldReturnArtist()
        {
            // arrange
            var id = Guid.NewGuid();

            var service = new Mock<IArtistService>();

            service.Setup(s => s.Get(id))
                   .Returns(new Artist { Id = id });

            var controller = new ArtistController(service.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // act
            var response = controller.GetArtist(id);

            Artist actual;
            response.TryGetContentValue(out actual);

            // assert
            Assert.That(response.StatusCode == HttpStatusCode.OK);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id == id);
        }

        [Test]
        public void GetArtist_WithInvalidId_ShouldReturnNull()
        {
            // arrange
            var service = new Mock<IArtistService>();

            service.Setup(s => s.Get(Guid.NewGuid()))
                   .Returns((Guid id) => new Artist { Id = id });

            var controller = new ArtistController(service.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // act
            var response = controller.GetArtist(Guid.NewGuid());

            Artist actual;
            response.TryGetContentValue(out actual);

            // assert
            Assert.That(response.StatusCode == HttpStatusCode.OK);

            Assert.That(actual, Is.Null);
        }
    }
}

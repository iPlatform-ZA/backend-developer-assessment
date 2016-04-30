using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using NUnit.Framework;

using Moq;

using ArtistApi.Controllers;
using ArtistApi.Models;
using ArtistDAL.Models;
using ArtistService.Services;

namespace ArtistTests
{
    [TestFixture]
    public class ArtistControllerTests
    {
        private ArtistController controller;
        private Mock<IArtistService> service;

        public ArtistControllerTests()
        {
            service = new Mock<IArtistService>();

            controller = new ArtistController(service.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
        }

        [Test]
        public void GetArtists_ShouldReturnAllArtists()
        {
            // arrange
            var expected = new Artist[] { new Artist { Id = Guid.NewGuid() } };

            service.Setup(s => s.GetAll())
                   .Returns(expected);
            
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

            service.Setup(s => s.Get(id))
                   .Returns(new Artist { Id = id });

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
            service.Setup(s => s.Get(Guid.NewGuid()))
                   .Returns((Guid id) => new Artist { Id = id });

            // act
            var response = controller.GetArtist(Guid.NewGuid());

            Artist actual;
            response.TryGetContentValue(out actual);

            // assert
            Assert.That(response.StatusCode == HttpStatusCode.OK);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void SearchArtist_WithInvalidSearch_ShouldReturnNoContent()
        {
            // act
            var response = controller.Search("Invalid Search");

            // assert
            service.Verify(s => s.SearchArtists(It.IsAny<string>()));

            Assert.That(response.StatusCode == HttpStatusCode.NoContent);
        }

        [Test]
        public void SearchArtist_WithValidSearch_ShouldReturnSearchResults()
        {
            // arrange
            service.Setup(s => s.SearchArtists(It.IsAny<string>()))
                   .Returns((new Artist[] { new Artist { Name = "Search" } }).AsQueryable());

            // act
            var response = controller.Search("Search", 1, 5);

            SearchResult result;
            response.TryGetContentValue(out result);

            // assert
            service.Verify(s => s.SearchArtists(It.IsAny<string>()));

            Assert.That(response.StatusCode == HttpStatusCode.OK);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.PageNumber == 1);
            Assert.That(result.PageSize == 5);
            CollectionAssert.IsNotEmpty(result.Results);
        }
    }
}

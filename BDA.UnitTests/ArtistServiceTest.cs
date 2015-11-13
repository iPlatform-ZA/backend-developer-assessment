using BDA.Contracts;
using BDA.Services;
using Xunit;

namespace BDA.UnitTests
{

    public class ArtistServiceTest
    {
        IArtistService service;
        public ArtistServiceTest()
        {
            service = new ArtistService();
        }

        [Theory]
        [InlineData("c44e9c22-ef82-4a77-9bcd-af6c958446d6")]
        public void GetTopAlbums(string artistId)
        {
            var result = service.GetTopAlbums(artistId);
            Assert.Equal(10, result.Releases.Count);
        }

        [Theory]
        [InlineData("c44e9c22-ef82-4a77-9bcd-af6c958446d6")]
        public void GetReleases(string artistId)
        {
            var result = service.GetReleases(artistId);
            Assert.Equal(25, result.Releases.Count);
        }

        [Fact]
        public void GetAll()
        {
            var result = service.GetAll();
            Assert.Equal(15, result.results.Count);
        }


        [Theory]
        [InlineData("joh", 1, 10)]
        public void Search(string searchCriteria, string pageNumber, string pageSize)
        {
            var result = service.Search(searchCriteria, pageNumber, pageSize);
            Assert.Equal(6, result.results.Count);
        }
    }
}

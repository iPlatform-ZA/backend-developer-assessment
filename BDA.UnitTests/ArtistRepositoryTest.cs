using BDA.Repositories;
using Xunit;
using System.IO;
using System.Collections.Generic;
using BDA.Models;
using System.Linq;

namespace BDA.UnitTests
{

    public class ArtistRepositoryTest
    {

        ArtistRepository repository;
        public ArtistRepositoryTest()
        {
           
            repository = new ArtistRepository();

        }
        [Fact]
        public void GetAllArtists()
        {
            int result = repository.GetAll().Count();
            Assert.Equal(15, result);
        }

        [Theory]
        [InlineData("joh", 1, 10)]
        public void SearchArtists(string searchCriteria, int pageNumber, int pageSize)
        {
            var result = repository.Search(searchCriteria, pageNumber, pageSize);
            Assert.Equal(6, result.Count());
        }

     




        


    }
}

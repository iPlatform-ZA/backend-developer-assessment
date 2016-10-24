using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Structure.Contracts;
using System.Linq;
namespace Structure.Tests
{
    [TestClass]
    public class AdapterTests
    {
        [TestMethod]
        public void TestArtistsSearch()
        {
            var provider = new Providers.ArtistsProvider();
            var searchArgs = new ArtistSearchArgs
            {
                Name = "John"
            };
            var paging = new PagingArgs
            {
                Page_Number = 1,
                Page_Size = 10
            };
            var results = provider.Search(searchArgs, paging);
            Assert.IsNotNull(results);
            Assert.AreEqual(6, results.NumberOfSearchResults);
            Assert.AreEqual(1, results.NumberOfPages);
            Assert.AreEqual(results.NumberOfSearchResults, results.Results.Count());
            Assert.AreEqual(paging.Page_Size, results.PageSize);
            Assert.AreEqual(paging.Page_Number, results.Page);
        }

        [TestMethod]
        public void TestNegativeArtistsSearch()
        {
            var provider = new Providers.ArtistsProvider();
            var searchArgs = new ArtistSearchArgs
            {
                Name = "Mpho Majenge"
            };
            var paging = new PagingArgs
            {
                Page_Number = 1,
                Page_Size = 10
            };
            var results = provider.Search(searchArgs, paging);
            Assert.IsNotNull(results);
            Assert.AreEqual(0, results.NumberOfSearchResults);     
        }
    }
}

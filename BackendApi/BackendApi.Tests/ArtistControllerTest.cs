using BackendApi.Controllers;
using BackendApi.Models;
using BackendApi.Tests.Helpers;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace BackendApi.Tests
{
    public class ArtistControllerTest
    {
        [Fact(DisplayName ="Search for artist must return those with search term")]
        public void SearchArtistNameShouldReturnCorrectArtists()
        {
            var context = new FakeContext();
            var sutController = new ArtistController(context);
            var result=sutController.Get("J", 1, 5) as   OkNegotiatedContentResult<ArtistResultModel>;
            Assert.Equal(result.Content.ResultsCount, 7);
        }

        [Theory(DisplayName ="Search for artist should return the correct count")]
        [InlineData("joh",1,5,6)]
        [InlineData("meg", 1, 5,1)]
        [InlineData("gb", 1, 5,4)]

        public void SearchArtistNameShouldReturnResultSet(string keyword,int page,int pageSize, int resultCount)
        {
            var context = new FakeContext();
            var sutController = new ArtistController(context);
            var result = sutController.Get(keyword, page, pageSize) as OkNegotiatedContentResult<ArtistResultModel>;
            Assert.Equal(result.Content.ResultsCount, resultCount);
        }
    }
}

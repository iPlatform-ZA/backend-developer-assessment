using Xunit;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Tests
{
    public class PagedResultTests
    {

        private List<Person> _persons = new List<Person>()
        {
            new Person() { Age = 10, Name = "Marcelle" },
            new Person() { Age = 21, Name = "Alex" },
            new Person() { Age = 32, Name = "Arron" },
            new Person() { Age = 43, Name = "Morgan" },
            new Person() { Age = 54, Name = "Skylar" }
        };

        public static IEnumerable<object[]> PageSizeAndNumbers
        {
            get
            {
                return new[]
                {
                    new object[] { 3, 1},
                    new object[] { 3, 2 },                    
                    new object[] { 2, 1 },
                    new object[] { 2, 2 },
                    new object[] { 2, 3 },
                };
            }
        }
        
        [Fact]
        public void PagedResult_Results_NullAsListReturnsNull()
        {
            var pagedResult = new SearchResult<int>(null, 5, 1);

            Assert.True(pagedResult.Results == null);
        }
        
        [Theory, MemberData("PageSizeAndNumbers")]
        public void PagedResult_CurrentPageItems_PageContainsNumerOfItemsLessOrEqualToSpecifiedPageSize(int pageSize, int pageNumber)
        {
            var pagedResult = new SearchResult<Person>(_persons, pageSize, pageNumber);

            Assert.True(pagedResult.Results.Count() <= pageSize);
        }

        [Fact]
        public void PagedResult_Results_ContainsExpectedItemsForGivenPageAndPageSize()
        {
            var pagedResult = new SearchResult<Person>(_persons, 2, 2);

            List<Person> expected = new List<Person> { _persons[2], _persons[3] };

            Assert.True(pagedResult.Results.All(i => expected.Contains(i)));
        }

        public class Person
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}

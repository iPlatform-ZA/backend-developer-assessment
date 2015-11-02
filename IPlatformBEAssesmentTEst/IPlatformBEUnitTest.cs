using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Persistance.Interfaces;
using Persistance;
using Domain;
using System.Data.Entity;
using System.Linq;

namespace IPlatformBEAssesmentTEst
{
    /// <summary>
    /// Summary description for IPlatformBEUnitTest
    /// </summary>
    [TestClass]
    public class IPlatformBEUnitTest
    {       
        public IPlatformBEUnitTest()
        {
            
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        [TestMethod]
        public void RepositoryGetArtistsTest()
        {
            var data = new List<Artist>{
                new Artist{Id = 1, Name = "Ronald", Country = "ZW", Identifier = "abc", Eliases = new List<Elias>{new Elias {Id = 1, EliasName = "Ron", ArtistId = 1}}},
                new Artist{Id = 2, Name = "Zebra", Country = "SA", Identifier = "bvf", Eliases = new List<Elias>{new Elias {Id = 2, EliasName = "Zeb", ArtistId = 2}}}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Artist>>();
            mockSet.As<IQueryable<Artist>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Artist>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Artist>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Artist>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BEContext>();
            mockContext.Setup(m => m.Artists).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<Artist>()).Returns(mockSet.Object);

            var repo = new Repository<Artist>(mockContext.Object);

            var list = repo.GetArtists(q => q.Name.Contains("Ron"));


            Assert.AreEqual(1, list.Count());
            Assert.AreEqual("ZW", list.FirstOrDefault().Country);
        }


        [TestMethod]
        public void RepositoryGetArtistById()
        {
            const int expectedId = 3;
            var expected = new Artist { Id = expectedId, Name = "WWWW", Country = "WEE", Identifier = "dfr" };

            var data = new List<Artist>{
                expected,
                new Artist{Id = 1, Name = "Ronald", Country = "ZW", Identifier = "abc", Eliases = new List<Elias>{new Elias {Id = 1, EliasName = "Ron", ArtistId = 1}}},
                new Artist{Id = 2, Name = "Zebra", Country = "SA", Identifier = "bvf", Eliases = new List<Elias>{new Elias {Id = 2, EliasName = "Zeb", ArtistId = 2}}}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Artist>>();
            mockSet.As<IQueryable<Artist>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Artist>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Artist>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Artist>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            

            var mockContext = new Mock<BEContext>();
            mockContext.Setup(m => m.Artists).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<Artist>()).Returns(mockSet.Object);

            var repo = new Repository<Artist>(mockContext.Object);
            
            var list = repo.GetArtistById(expectedId);

            Assert.AreEqual(1, list.Id);
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            
            //
            // TODO: Add test logic here
            //
        }
    }
}

using Xunit;
using Backend_Assessment.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend_Assessment.Models;
using Rhino.Mocks;
using Backend_Assessment.Services;

namespace Backend_Assessment.Paging.Tests
{
    public class PagedListTests
    {
        [Fact()]
        public void PagedListTest()
        {
            var musicBrainzService = MockRepository.GenerateMock<MusicBrainzService>();
            musicBrainzService.Stub(x => x.GetReleases(string.Empty)).Return((
                new List<EntityModels.Release>()
                {
                    new EntityModels.Release() { Title = "Abc", Id= Guid.NewGuid().ToString(), TrackCount = (new Random()).Next(26), Status="Official", NameCredit = new List<EntityModels.ReleaseArtist>() { new EntityModels.ReleaseArtist() { Id = Guid.NewGuid().ToString(), Name = "Abc" } } }
                }).AsQueryable());

            Assert.True(false, "This test needs an implementation");
        }
    }
}
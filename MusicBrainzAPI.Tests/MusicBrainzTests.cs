using Xunit;
using System;
using System.Collections.Generic;

namespace MusicBrainsAPI.Tests
{
    public class MusicBrainzTests
    {
        // The MusicBrainz artist ID for 
        private static readonly Guid knownArtistId = new Guid("c44e9c22-ef82-4a77-9bcd-af6c958446d6");

        private static readonly Guid invalidArtistId = Guid.Empty;

        private static readonly Guid[] knownReleaseIds = new Guid[]
        {
            new Guid("34c2b7b8-4403-4110-8c07-d204739705ec"),
            new Guid("d751cba4-242e-46d8-b230-3ca1d4e59b85"),
            new Guid("ed1dc3fc-5475-4e4d-8ba6-bb4871d02987")
        };

        [Fact]
        public void MusicBrainz_GetReleaseByArtistsId_ReturnsResultForKnownArtistId()
        {
            var searchResult = MusicBrainz.GetReleasesByArtistId(knownArtistId);

            Assert.True(searchResult.Success == true && searchResult.Result.Length > 0);
        }

        [Fact]
        public void MusicBrainz_GetReleaseByArtistsId_ReturnsNoResultsForInvalidArtistId()
        {
            var searchResult = MusicBrainz.GetReleasesByArtistId(invalidArtistId);

            Assert.True(searchResult.Success == true && searchResult.Result.Length == 0);
        }
        
        [Fact]
        public void MusicBrainz_GetReleaseByReleaseId_ReturnsResultForKnownReleaseIds()
        {
            var searchResult = MusicBrainz.GetReleasesByReleaseId(knownReleaseIds);

            Assert.True(searchResult.Success == true && searchResult.Result.Length > 0);
        }

        [Fact]
        public void MusicBrainz_GetReleaseGroupsByArtistId_ReturnsResultForKnownArtistId()
        {
            var searchResult = MusicBrainz.GetReleaseGroupsByArtistId(knownArtistId);

            Assert.True(searchResult.Success == true && searchResult.Result.Length > 0);
        }

        [Fact]
        public void MusicBrainz_GetReleaseGroupsByArtistId_ReturnsNoResultsForInvalidArtistId()
        {
            var searchResult = MusicBrainz.GetReleaseGroupsByArtistId(invalidArtistId);

            Assert.True(searchResult.Success == true && searchResult.Result.Length == 0);
        }
    }
}
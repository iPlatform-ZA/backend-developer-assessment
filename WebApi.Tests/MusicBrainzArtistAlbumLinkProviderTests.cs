using Xunit;
using WebApi.Models;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

namespace WebApi.Tests
{
    public class MusicBrainzArtistAlbumLinkProviderTests
    {
        private string _baseUrl = "http://musicbrainz.org/artist";

        public static IEnumerable<object[]> RandomGuids
        {
            get
            {
                return new[] 
                {
                    new object[] { Guid.NewGuid() },
                    new object[] { Guid.NewGuid() },
                    new object[] { Guid.NewGuid() }
                };
            }
        }

        [Fact]
        public void MusicBrainzArtistAlbumLinkProvider_DefaultConstructor_ReturnsDefualtBaseUrl()
        {
            MusicBrainzArtistAlbumLinkProvider linkProvider = new MusicBrainzArtistAlbumLinkProvider();

            Assert.Equal(linkProvider.MusicBrainzArtistAlbumsBaseUrl, _baseUrl);
        }

        [Theory]
        [InlineData("http://url1/foo")]
        [InlineData("https://url1/bar")]
        public void MusicBrainzArtistAlbumLinkProvider_OverloadedConstructor_ReturnsSpecifiedBaseUrl(string specifiedUrl)
        {
            MusicBrainzArtistAlbumLinkProvider linkProvider = new MusicBrainzArtistAlbumLinkProvider(specifiedUrl);

            Assert.Equal(linkProvider.MusicBrainzArtistAlbumsBaseUrl, specifiedUrl);
        }

        [Theory]
        [InlineData("http://url1/foo/")]
        [InlineData("https://url1/bar////")]
        public void MusicBrainzArtistAlbumLinkProvider_SpecifiedUrlHasTrailingSlashes_TrailingSlashesAreRmoved(string specifiedUrl)
        {
            MusicBrainzArtistAlbumLinkProvider linkProvider = new MusicBrainzArtistAlbumLinkProvider(specifiedUrl);

            Assert.False(Regex.IsMatch(linkProvider.MusicBrainzArtistAlbumsBaseUrl, @"/+$"));
        }

        [Theory, MemberData("RandomGuids")]
        
        public void GetLinkToArtistAlbums_DefaultConstructorUsedAndArtistIdentifiersAreSpecified_ReturnsConcatenatedDefaultBaseUrlAndArtistId(Guid artistId)
        {
            MusicBrainzArtistAlbumLinkProvider linkProvider = new MusicBrainzArtistAlbumLinkProvider();

            string expectedValue = $"{_baseUrl}/{artistId}";
            string link = linkProvider.GetLinkToArtistAlbums(artistId);

            Assert.Equal(link, expectedValue);
        }

        [Theory, MemberData("RandomGuids")]
        public void GetLinkToArtistAlbums_OverloadedConstructorUsedAndArtistIdentifiersAreSpecified_ReturnsConcatenatedDefaultBaseUrlAndArtistId(Guid artistId)
        {
            string specificUrl = "http://foo/bar/";

            MusicBrainzArtistAlbumLinkProvider linkProvider = new MusicBrainzArtistAlbumLinkProvider(specificUrl);

            string expectedValue = $"{linkProvider.MusicBrainzArtistAlbumsBaseUrl}/{artistId}";
            string link = linkProvider.GetLinkToArtistAlbums(artistId);

            Assert.Equal(link, expectedValue);
        }
    }
}

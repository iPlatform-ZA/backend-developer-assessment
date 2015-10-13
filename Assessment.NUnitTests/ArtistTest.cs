using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using NUnit.Framework;

using Assessment.BusinessLogic.Contracts;
using Assessment.BusinessLogic.Implementations;
using Assessment.BusinessLogic.Common;
using Assessment.Models.DTO;
using Assessment.Models.ThirdParty.MusicBrainz;

namespace Assessment.NUnitTests
{
    [TestFixture]
    public class ArtistTest
    {
        [Test]
        public void GetArtistAliases()
        {
            Artist<AliasDTO> artist = new Artist<AliasDTO>();
            List<string> aliases = artist.GetArtistAliases(1);

            Assert.That(artist, Is.InstanceOf<Artist<AliasDTO>>());
            Assert.That(aliases, Is.InstanceOf<List<string>>());
        }

        [Test]
        public void GetArtists()
        {
            Artist<ResultDTO<ArtistDTO>> artist = new Artist<ResultDTO<ArtistDTO>>();
            Task<ResultDTO<ArtistDTO>> result = artist.GetArtists("joh", 0, 5);

            Assert.That(artist, Is.InstanceOf<Artist<ResultDTO<ArtistDTO>>>());
            Assert.That(result, Is.InstanceOf<Task<ResultDTO<ArtistDTO>>>());
        }

        [Test]
        public void GetArtistAlbums()
        {
            Artist<List<AlbumDTO>> artist = new Artist<List<AlbumDTO>>();
            Task<List<AlbumDTO>> result = artist.GetArtistAlbums("65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab");

            Assert.That(artist, Is.InstanceOf<Artist<List<AlbumDTO>>>());
            Assert.That(result, Is.InstanceOf<Task<List<AlbumDTO>>>());
        }

        [Test]
        public void GetArtistReleases()
        {
            Artist<ResultDTO<ReleaseInfoDTO>> artist = new Artist<ResultDTO<ReleaseInfoDTO>>();
            Task<ResultDTO<ReleaseInfoDTO>> result = artist.GetArtistReleases("65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab");

            Assert.That(artist, Is.InstanceOf<Artist<ResultDTO<ReleaseInfoDTO>>>());
            Assert.That(result, Is.InstanceOf<Task<ResultDTO<ReleaseInfoDTO>>>());
        }
    }
}

namespace Structure
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A music brainz extension mappers.
    /// </summary>
    public static class MusicBrainzExtensionMappers
    {
        /// <summary>
        /// A Contracts.MusicBrainz.Release extension method that maps the given release.
        /// </summary>
        /// <param name="release">The release.</param>
        /// <returns>
        /// A Release.
        /// </returns>
        public static Release Map(this Contracts.MusicBrainz.Release release)
        {
            return new Release
            {
                Label = release.LabelInfo.FirstOrDefault().Label.Name,
                NumberOfTracks = release.TrackCount,
                ReleaseId = Guid.Parse(release.Id),
                Status = release.Status,
                Title = release.Title,
                OtherArtists = release.ArtistCredit.Select(artist => new { Id = artist.Artist.Id, Name = artist.Artist.Name })
            };
        }

        /// <summary>
        /// A Contracts.MusicBrainz.Release extension method that maps the given release.
        /// </summary>
        /// <param name="releases">The releases.</param>
        /// <returns>
        /// A Release.
        /// </returns>
        public static IEnumerable<Release> Map(this IEnumerable<Contracts.MusicBrainz.Release> releases)
        {
            return releases.Select(release => release.Map());
        }
    }
}

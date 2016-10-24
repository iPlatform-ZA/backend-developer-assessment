
namespace Structure.Adapters.MusicBrainz
{
    using Contracts;
    using Contracts.MusicBrainz;
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Interface for music brainz adapter.
    /// </summary>
    public interface IMusicBrainzAdapter
    {
        /// <summary>
        /// Gets the artist releases.
        /// </summary>
        /// <param name="artistId">Identifier for the artist.</param>
        /// <param name="paging">The paging.</param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process the artist releases in this collection.
        /// </returns>
        ReleasesResponse GetArtistReleases(Guid artistId, PagingArgs paging);
    }
}

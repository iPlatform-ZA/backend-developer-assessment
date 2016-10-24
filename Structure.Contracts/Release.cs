
namespace Structure.Contracts
{
    using System;

    /// <summary>
    /// A release.
    /// </summary>
    public class Release
    {
        /// <summary>
        /// Gets or sets the identifier of the release.
        /// </summary>
        public Guid ReleaseId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the number of tracks.
        /// </summary>
        public int NumberOfTracks { get; set; }

        /// <summary>
        /// Gets or sets the other artists.
        /// </summary>
        public object OtherArtists { get; set; }
    }
}

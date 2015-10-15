using System;
using System.Runtime.Serialization;
using MusicBrainzApi.Domain.Releases;

namespace App.Services.Domain
{
    [DataContract]
    public class Release
    {
        /// <summary>
        /// The Release Id
        /// </summary>
        [DataMember]
        public Guid releaseId { get; set; }

        /// <summary>
        /// Release Title
        /// </summary>
        [DataMember]
        public string title { get; set; }

        /// <summary>
        /// Release Status
        /// </summary>
        [DataMember]
        public string status { get; set; }

        /// <summary>
        /// Release Label
        /// </summary>
        [DataMember]
        public string label { get; set; }

        /// <summary>
        /// Release Number of Tracks
        /// </summary>
        [DataMember]
        public int numberOfTracks { get; set; }

        /// <summary>
        /// Release Other Artists.
        /// </summary>
        [DataMember]
        public OtherArtists[] otherArtists { get; set; }
   }
}

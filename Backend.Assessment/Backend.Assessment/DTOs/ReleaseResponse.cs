using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Backend.Assessment.DTOs
{
    [DataContract]
    public class ReleaseResponse
    {
        [DataMember(Name = "releaseId")]
        public string ReleaseId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name = "numberOfTracks")]
        public string NumberOfTracks { get; set; }

        [DataMember(Name = "otherArtists")]
        public List<OtherArtistResponse> OtherArtists { get; set; }
    }
}
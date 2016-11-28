using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Backend.Assessment.DTOs
{
    [DataContract]
    public class AlbumResponse
    {
        [DataMember(Name = "releases")]
        public List<ReleaseResponse> Releases { get; set; }
    }
}

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Backend.Assessment.DTOs
{
    [DataContract]
    public class ArtistResponse
    {
        [DataMember(Name = "results")]
        public List<ArtistCollectionResponse> ArtistCollectionResponse { get; set; }

        [DataMember(Name = "numberOfSearchResults")]
        public int NumberOfSearchResults { get; set; }

        [DataMember(Name = "page")]
        public string Page { get; set; }

        [DataMember(Name = "pageSize")]
        public string PageSize { get; set; }

        [DataMember(Name = "numberOfPages")]
        public string NumberOfPages { get; set; }
    }
}
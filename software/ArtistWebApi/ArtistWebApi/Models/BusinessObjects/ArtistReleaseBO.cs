using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistWebApi.Models.BusinessObjects
{
    public class ArtistReleaseBO
    {
        [JsonProperty(PropertyName = "releaseId")]
        public string ReleaseId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        [JsonProperty(PropertyName = "numberOfTracks")]
        public int NumberOfTracks { get; set; }

        [JsonProperty(PropertyName = "otherArtists")]
        public List<ArtistBaseBO> OtherArtists { get; set; }

        public ArtistReleaseBO()
        { 
           
        }


    }
}
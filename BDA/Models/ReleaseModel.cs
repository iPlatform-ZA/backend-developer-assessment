using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDA.Models
{
    public class ReleaseModel
    {
        public ReleaseModel()
        {
            OtherArtists = new List<OtherArtistModel>();
        }

        [JsonProperty("releaseId")]
        public string ReleaseId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("numberOfTracks")]
        public string NumberOfTracks { get; set; }

        [JsonProperty("otherArtists")]
        public List<OtherArtistModel> OtherArtists { get; set; }


    }
}
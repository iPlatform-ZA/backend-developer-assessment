using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendApi.Models
{
    public class ArtistReleaseModel
    {
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("offset")]
        public int Offset { get; set; }
        [JsonProperty("releases")]
        public Release[] Releases { get; set; }
    }
}
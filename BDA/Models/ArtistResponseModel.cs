using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDA.Models
{
    public class ArtistResponseModel
    {
        [JsonProperty("results")]
        public List<ArtistModel> results { get; set; }

        [JsonProperty("numberOfSearchResults")]
        public int numberOfSearchResults { get; set; }

        [JsonProperty("pageSize")]
        public int pageSize { get; set; }

        [JsonProperty("page")]
        public int page { get; set; }

        [JsonProperty("numberOfPages")]
        public int numberOfPages { get; set; }

    }
}
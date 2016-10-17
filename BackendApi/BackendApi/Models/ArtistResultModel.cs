using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendApi.Models
{
    public class ArtistResultModel
    {
        [JsonProperty("results")]
        public IEnumerable<Artist>  Artist { get; set; }
        [JsonProperty("numberOfSearchResults")]
        public int ResultsCount { get; set; }
        [JsonProperty("page")]
        public int CurrentPage { get; set; }
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
        [JsonProperty("numberOfPages")]
        public int Pages { get; set; }
  

    }
}
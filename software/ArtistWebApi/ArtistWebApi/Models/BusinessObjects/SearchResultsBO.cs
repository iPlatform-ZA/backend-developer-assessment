using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistWebApi.Models.BusinessObjects
{
    public class SearchResultsBO
    {
        [JsonProperty(PropertyName = "results")]
        public IEnumerable<ArtistBO> Results { get; set; }

        [JsonProperty(PropertyName = "numberOfSearchResults")]
        public int NumberOfSearchResults { get; set; }

        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "numberOfPages")]
        public int NumberOfPages { get; set; }

        public SearchResultsBO()
        { 
        
        }
    }
}
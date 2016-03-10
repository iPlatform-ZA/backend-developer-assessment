using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistWebApi.Models.BusinessObjects
{
    public class ArtistBO
    {
        [JsonIgnore]
        public System.Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "alias")]
        public List<string> Alias { get; set; }

        public ArtistBO()
        { 
        }

    }
}
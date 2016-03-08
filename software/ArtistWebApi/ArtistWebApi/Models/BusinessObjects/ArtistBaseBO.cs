using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistWebApi.Models.BusinessObjects
{
    public class ArtistBaseBO
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public ArtistBaseBO()
        { 
        }
    }
}
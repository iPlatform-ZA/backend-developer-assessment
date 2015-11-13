using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDA.Models
{
    public class ArtistModel
    {

        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("artistName")]
        public string ArtistName { get; set; }

        [JsonProperty("uniqueIdentifier")]
        [JsonIgnore]
        public System.Guid UniqueIdentifier { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("aliases")]
        //csv list of alliases
        public List<string> Aliases { get; set; }

        [JsonProperty("albumLink")]
        public string  AlbumLink
        {
            get { return String.Format("{0}/artist/{1}/releases",Global.GlobalUri,UniqueIdentifier); }
         
        }
        
    }
}
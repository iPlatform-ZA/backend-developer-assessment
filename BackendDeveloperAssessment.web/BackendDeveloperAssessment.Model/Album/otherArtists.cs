using Newtonsoft.Json;
using System.Collections.Generic;

namespace BackendDeveloperAssessment.Model.Album
{
    public class otherArtists
    {
        [JsonProperty(PropertyName = "artist")]
        public artistdetail artist { get; set; }
    }
}
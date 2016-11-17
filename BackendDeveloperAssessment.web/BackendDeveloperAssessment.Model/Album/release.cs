using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperAssessment.Model.Album
{
    public class release
    {
        [JsonProperty(PropertyName = "id")]
        public string releaseId { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        [JsonProperty(PropertyName = "label-info")]
        public List<labelinfo> labelinfo { get; set; }
        [JsonProperty(PropertyName = "track-count")]
        public int numberOfTracks { get; set; }
        [JsonProperty(PropertyName = "artist-credit")]
        public List<otherArtists> otherArtists { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assessment.Models.ThirdParty.MusicBrainz
{
    public class MBMediaDTO
    {
        public string title { get; set; }
        public string format { get; set; }
        public int position { get; set; }

        [JsonProperty(PropertyName = "track-count")]
        public int trackcount { get; set; }
    }
}

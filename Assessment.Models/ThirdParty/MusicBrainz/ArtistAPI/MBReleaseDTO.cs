using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assessment.Models.ThirdParty.MusicBrainz
{
    public class MBReleaseDTO
    {
        public string id { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string quality { get; set; }
        public string disambiguation { get; set; }
        public string packaging { get; set; }
        public string country { get; set; }
        public string barcode { get; set; }
        public string date { get; set; }

        [JsonProperty(PropertyName = "release-events")]
        public List<MBReleaseEventsDTO> releaseevents { get; set; }

        [JsonProperty(PropertyName = "text-representation")]
        public MBTextRepresentationDTO textrepresentation { get; set; }
    }
}
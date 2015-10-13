using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assessment.Models.ThirdParty.MusicBrainz
{
    public class MBArtistReleaseDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string disambiguation { get; set; }
        public string country { get; set; }
        public string gender { get; set; }
        public string type { get; set; }
        public List<string> ipis { get; set; }
        public MBAreaDTO area { get; set; }
        public MBAreaDTO end_area { get; set; }
        public MBAreaDTO begin_area { get; set; }
        public List<MBReleaseDTO> releases { get; set; }

        [JsonProperty(PropertyName = "sort-name")]
        public string sortname { get; set; }

        [JsonProperty(PropertyName = "life-span")]
        public MBLifeSpanDTO lifespan { get; set; }
    }
}
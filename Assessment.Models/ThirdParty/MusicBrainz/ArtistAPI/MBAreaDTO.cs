using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assessment.Models.ThirdParty.MusicBrainz
{
    public class MBAreaDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string disambiguation { get; set; }
        public List<string> iso_3166_1_codes { get; set; }
        public List<string> iso_3166_2_codes { get; set; }
        public List<string> iso_3166_3_codes { get; set; }

        [JsonProperty(PropertyName = "sort-name")]
        public string sortname { get; set; }
    }
}

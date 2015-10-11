using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assessment.Models.ThirdParty.MusicBrainz
{
    public class MBLabelInfoDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string disambiguation { get; set; }

        [JsonProperty(PropertyName = "label-code")]
        public string labelcode { get; set; }

        [JsonProperty(PropertyName = "sort-name")]
        public string sortname { get; set; }
    }
}


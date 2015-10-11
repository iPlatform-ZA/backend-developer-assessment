using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assessment.Models.ThirdParty.MusicBrainz
{
    public class MBArtistDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string disambiguation { get; set; }

        //Custom JSON Properties
        [JsonProperty(PropertyName = "sort-name")]
        public string sortname { get; set; }
    }
}

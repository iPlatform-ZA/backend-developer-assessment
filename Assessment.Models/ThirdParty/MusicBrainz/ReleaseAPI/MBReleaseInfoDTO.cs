using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assessment.Models.ThirdParty.MusicBrainz
{
    //Commit changes
    public class MBReleaseInfoDTO
    {
        public string id { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string quality { get; set; }
        public string asin { get; set; }
        public string date { get; set; }
        public string barcode { get; set; }
        public string disambiguation { get; set; }
        public string country { get; set; }
        public string packaging { get; set; }
        public List<MBMediaDTO> media { get; set; }


        [JsonProperty(PropertyName = "label-info")]
        public List<MBLabelDTO> labelinfo { get; set; }
        
        [JsonProperty(PropertyName = "artist-credit")]
        public List<MBArtistCreditDTO> artistcredit { get; set; }

        [JsonProperty(PropertyName = "cover-art-archive")]
        public MBCoverArtArchiveDTO coverartarchive { get; set; }

        [JsonProperty(PropertyName = "release-events")]
        public List<MBReleaseEventsDTO> releaseevents { get; set; }

        [JsonProperty(PropertyName = "text-representation")]
        public MBTextRepresentationDTO textrepresentation { get; set; }
    }
}
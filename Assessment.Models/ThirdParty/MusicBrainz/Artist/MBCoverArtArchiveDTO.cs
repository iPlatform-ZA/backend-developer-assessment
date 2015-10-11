using System;
using System.Collections.Generic;

namespace Assessment.Models.ThirdParty.MusicBrainz
{
    public class MBCoverArtArchiveDTO
    {
        public int count {get; set;}
        public bool darkened {get; set;}
        public bool front {get; set;}
        public bool artwork {get; set;}
        public bool back {get; set;}
    }
}
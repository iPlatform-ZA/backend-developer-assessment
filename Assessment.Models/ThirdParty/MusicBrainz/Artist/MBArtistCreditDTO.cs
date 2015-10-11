using System;
using System.Collections.Generic;

namespace Assessment.Models.ThirdParty.MusicBrainz
{
    public class MBArtistCreditDTO
    {
        public string name { get; set; }
        public string joinphrase { get; set; }

        public MBArtistDTO artist { get; set; }
    }
}

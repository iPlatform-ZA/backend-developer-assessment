using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assessment.Models.ThirdParty.MusicBrainz
{
    public class MBLabelDTO
    {
        public string catalognumber { get; set; }

        public MBLabelInfoDTO label { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndApplication.MusicBrains
{
    public class Release
    {
        public string id { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string label { get; set; }
        public string numberOfTracks { get; set; }
        public List<Artist> otherArtists { get; set; }
    }
}
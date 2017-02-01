using DAL.MusicBrainzJsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Album
    {
        public string releaseId { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string label { get; set; }
        public int numberOfTracks { get; set; }
        public List<OtherArtist> otherArtist { get; set; }
    }
}

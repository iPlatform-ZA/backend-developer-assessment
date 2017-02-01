using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MusicBrainzJsonModel
{

    public class Rootobject
    {
        public DateTime created { get; set; }
        public int count { get; set; }
        public int offset { get; set; }
        public Release[] releases { get; set; }
    }

    public class Release
    {
        public string id { get; set; }
        public string score { get; set; }
        public int count { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public TextRepresentation textrepresentation { get; set; }
        public List<ArtistCredit> artistcredit { get; set; }
        public ReleaseGroup releasegroup { get; set; }
        public string date { get; set; }
        public string country { get; set; }
        public List<ReleaseEvents> releaseevents { get; set; }
        public string barcode { get; set; }
        public List<LabelInfo> labelinfo { get; set; }
        public int trackcount { get; set; }
        public List<Medium> media { get; set; }
        public string asin { get; set; }
        public string packaging { get; set; }
    }

    public class TextRepresentation
    {
        public string language { get; set; }
        public string script { get; set; }
    }

    public class ReleaseGroup
    {
        public string id { get; set; }
        public string primarytype { get; set; }
        public string[] secondarytypes { get; set; }
    }

    public class ArtistCredit
    {
        public Artist artist { get; set; }
    }

    public class OtherArtist
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Artist
    {
        public string id { get; set; }
        public string name { get; set; }
        public string sortname { get; set; }
        public Alias[] aliases { get; set; }
    }

    public class Alias
    {
        public string sortname { get; set; }
        public string name { get; set; }
        public string locale { get; set; }
        public string type { get; set; }
        public object primary { get; set; }
        public object begindate { get; set; }
        public object enddate { get; set; }
    }

    public class ReleaseEvents
    {
        public string date { get; set; }
        public Area area { get; set; }
    }

    public class Area
    {
        public string id { get; set; }
        public string name { get; set; }
        public string sortname { get; set; }
        public string[] iso31661codes { get; set; }
    }

    public class LabelInfo
    {
        public string catalognumber { get; set; }
        public Label label { get; set; }
    }

    public class Label
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Medium
    {
        public string format { get; set; }
        public int disccount { get; set; }
        public int trackcount { get; set; }
    }


}

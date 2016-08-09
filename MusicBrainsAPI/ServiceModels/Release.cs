using System;
using System.Xml.Serialization;

namespace MusicBrainsAPI.ServiceModels
{
    public class Release
    {
        [XmlAttribute("id")]
        public Guid ID { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("status")]
        public string Status { get; set; }

        [XmlElement("date")]
        public DateTime Date { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }

        [XmlElement("label-info-list")]
        public LabelnfoList LabelInfoList { get; set; }

        [XmlElement("medium-list")]
        public MediumList MediumList { get; set; }

        [XmlElement("artist-credit")]
        public ArtistCredit ArtistCredit { get; set; }
    }
}
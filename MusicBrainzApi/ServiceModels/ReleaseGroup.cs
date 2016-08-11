using System;
using System.Xml.Serialization;

namespace MusicBrainsAPI.ServiceModels
{
    public class ReleaseGroup
    {
        [XmlAttribute("id")]
        public Guid ID { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("primary-type")]
        public string PrimaryType { get; set; }

        [XmlElement("artist-credit")]
        public ArtistCredit ArtistCredit { get; set; }

        [XmlElement("release-list")]
        public ReleaseList ReleaseList { get; set; }
    }
}
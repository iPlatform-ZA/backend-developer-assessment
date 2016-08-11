using System;
using System.Xml.Serialization;

namespace MusicBrainsAPI.ServiceModels
{
    [XmlRoot(Namespace = "http://musicbrainz.org/ns/mmd-2.0#", IsNullable = false, ElementName = "metadata")]
    public partial class SearchReleaseResponse
    {
        [XmlElement("release-list")]
        public ReleaseList ReleaseList { get; set; }

        [XmlAttribute("created")]
        public DateTime DateCreated { get; set; }
    }
}

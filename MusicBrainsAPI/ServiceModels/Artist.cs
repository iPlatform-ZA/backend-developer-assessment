using System;
using System.Xml.Serialization;

namespace MusicBrainsAPI.ServiceModels
{
    public class Artist
    {
        [XmlAttribute("id")]
        public Guid ID { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("alias-list")]
        public AliasList AliasList { get; set; }
    }
}

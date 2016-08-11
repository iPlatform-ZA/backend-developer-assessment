using System;
using System.Xml.Serialization;

namespace MusicBrainsAPI.ServiceModels
{
    public class Label
    {
        [XmlAttribute("id")]
        public Guid ID { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
    }
}

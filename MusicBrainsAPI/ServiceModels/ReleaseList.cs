using System.Xml.Serialization;

namespace MusicBrainsAPI.ServiceModels
{
    public class ReleaseList
    {
        [XmlAttribute]
        public int Count { get; set; }

        [XmlAttribute]
        public int Offset { get; set; }

        [XmlElement("release")]
        public Release[] Releases { get; set; }
    }
}

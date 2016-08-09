using System.Xml.Serialization;

namespace MusicBrainsAPI.ServiceModels
{
    public class NameCredit
    {
        [XmlElement("artist")]
        public Artist Artists { get; set; }
    }
}
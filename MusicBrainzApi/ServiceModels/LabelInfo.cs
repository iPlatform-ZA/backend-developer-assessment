using System.Xml.Serialization;

namespace MusicBrainsAPI.ServiceModels
{
    public class LabelInfo
    {
        [XmlElement("label")]
        public Label[] Labels { get; set; }
    }
}

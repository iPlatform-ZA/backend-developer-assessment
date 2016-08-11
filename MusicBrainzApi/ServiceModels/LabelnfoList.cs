using System.Xml.Serialization;

namespace MusicBrainsAPI.ServiceModels
{
    public class LabelnfoList
    {
        [XmlElement("label-info")]
        public LabelInfo[] LabelInfo { get; set; }
    }
}

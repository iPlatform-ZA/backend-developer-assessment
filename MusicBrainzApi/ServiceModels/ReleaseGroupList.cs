using System.Xml.Serialization;

namespace MusicBrainsAPI.ServiceModels
{
    public class ReleaseGroupList
    {
        [XmlElement("release-group")]
        public ReleaseGroup[] ReleaseGroups { get; set; }
    }
}

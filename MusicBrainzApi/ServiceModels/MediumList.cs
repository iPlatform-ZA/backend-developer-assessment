using System.Xml.Serialization;

namespace MusicBrainsAPI.ServiceModels
{
    public class MediumList
    {        
        [XmlElement("track-count")]
        public int TrackCount { get; set; }
    }
}

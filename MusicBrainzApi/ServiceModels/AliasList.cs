using System.Xml.Serialization;

namespace MusicBrainsAPI.ServiceModels
{
    public class AliasList
    {
        [XmlElement("alias")]
        public string[] Aliases { get; set; }
    }
}
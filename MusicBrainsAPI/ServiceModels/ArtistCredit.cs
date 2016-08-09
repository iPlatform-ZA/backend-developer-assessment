using System.Xml.Serialization;

namespace MusicBrainsAPI.ServiceModels
{
    public class ArtistCredit
    {
        [XmlElement("name-credit")]
        public NameCredit[] NameCredits { get; set; }
    }
}

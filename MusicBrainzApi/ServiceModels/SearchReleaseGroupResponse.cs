using System.Xml.Serialization;


namespace MusicBrainsAPI.ServiceModels
{
    [XmlRoot(Namespace = "http://musicbrainz.org/ns/mmd-2.0#", IsNullable = false, ElementName = "metadata")]
    public class SearchReleaseGroupResponse
    {
        [XmlElement("release-group-list")]
        public ReleaseGroupList ReleaseGoupList { get; set; }
    }
}

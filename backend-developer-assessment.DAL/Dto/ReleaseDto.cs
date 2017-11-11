using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace backend_developer_assessment.DAL.Dto
{
    [Serializable, XmlRoot(ElementName = "release-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class ReleaseDto
    {
        public ReleaseDto()
        {
            results = new List<ReleaseItem>();
        }
        
        [XmlElement("release")]
        public List<ReleaseItem> results { get; set; }
    }
    
    public class ReleaseItem
    {
        [XmlElement("title")]
        public string title { get; set; }
        [XmlElement("status")]
        public string status { get; set; }
        [XmlAttribute("id")]
        public string releaseId { get; set; }
    }
}

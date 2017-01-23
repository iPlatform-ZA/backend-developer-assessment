using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MusicBrainz.Platform.Domain
{
    /// <remarks />
    public class Iso31661Codelist
    {
        /// <remarks />
        public Iso31661Codelist()
        {
            Iso31661Code = string.Empty;
        }

        /// <remarks />
        [XmlElement("iso-3166-1-code")]
        public string Iso31661Code { get; set; }
    }

}

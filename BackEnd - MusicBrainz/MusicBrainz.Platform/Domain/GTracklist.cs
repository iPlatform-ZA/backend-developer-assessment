using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MusicBrainz.Platform.Domain
{
    /// <remarks />
    public class GTracklist
    {
        /// <remarks />
        public GTracklist()
        {
            Count = string.Empty;
        }

        /// <remarks />
        [XmlAttribute("count")]
        public string Count { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MusicBrainz.Platform.Domain
{
    /// <remarks />
    public class Alias
    {
        /// <remarks />
        public Alias()
        {
            Sortname = string.Empty;
            Type = string.Empty;
            Value = string.Empty;
        }

        /// <remarks />
        [XmlAttribute("sort-name")]
        public string Sortname { get; set; }

        /// <remarks />
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <remarks />
        [XmlText]
        public string Value { get; set; }
    }
}

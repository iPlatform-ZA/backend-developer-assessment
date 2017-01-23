using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainz.Platform.Domain
{
    public class Artist
    {
        public string Artistname { get; set; }
        [Key]
        public string Uniqueidentifier { get; set; }
        public string Country { get; set; }
        public string Aliases { get; set; }
    }

}

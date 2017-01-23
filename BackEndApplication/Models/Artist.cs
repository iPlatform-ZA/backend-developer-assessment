using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndApplication.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string UniqueIdentifier { get; set; }
        public string Country { get; set; }
        public string Aliases { get; set; }
    }
}
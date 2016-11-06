using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend_Assessment.Models
{
    public class Release
    {
        public string ReleaseId { get; set; }
        public string Title { get; set; }
        public string Label { get; set; }
        public string Status { get; set; }
        public int NumberOfTracks { get; set; }
        public List<EntityModels.ReleaseArtist> OtherArtists { get; set; }
    }
}
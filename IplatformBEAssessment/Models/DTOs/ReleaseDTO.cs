using IplatformBEAssessment.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IplatformBEAssessment.Models.DTOs
{
    public class ReleaseDTO
    {
        public ReleaseDTO()
        {
            OtherArtists = new List<OtherArtists>();
        }
        public string ReleaseId { get; set; }
        public string ReleaseTitle { get; set; }
        public string Status { get; set; }
        public string Label { get; set; }
        public int NumberOfTracks { get; set; }
        public ICollection<OtherArtists> OtherArtists { get; set; }

    }
}
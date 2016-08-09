using System;

namespace WebApi.Models
{
    public class Release
    {
        public Guid ReleaseId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Label { get; set; }
        public int NumberOfTracks { get; set; }
        //public Artist OtherArtists { get; set; }
    }
}
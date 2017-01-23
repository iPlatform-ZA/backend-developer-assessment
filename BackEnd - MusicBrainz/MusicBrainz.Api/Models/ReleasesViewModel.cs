using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicBrainz.Api.Models
{
    public class Releases
    {
        public string ReleaseId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Label { get; set; }
        public int NumberOfTracks { get; set; }
        public List<OtherArtist> OtherArtists { get; set; }
    }

    public class ReleasesViewModel
    {
        public List<Releases> Releases { get; set; }
    }

    public class OtherArtist
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
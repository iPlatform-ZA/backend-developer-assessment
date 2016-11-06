using System.Collections.Generic;

namespace Backend_Assessment.EntityModels
{
    public partial class Release
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Label { get; set; }
        public string Status { get; set; }
        public int TrackCount { get; set; }
        public List<ReleaseArtist> NameCredit { get; set; }
    }

    public partial class ReleaseArtist
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
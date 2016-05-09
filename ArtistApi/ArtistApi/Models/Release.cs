using System;
using System.Linq;
using System.Collections.Generic;

using MusicBrainz.Data;

namespace ArtistApi.Models
{
    public class Release
    {
        public string ReleaseId { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string Label { get; set; }

        public int NumberOfTracks { get; set; }

        public IEnumerable<ReleaseArtist> OtherArtists { get; set; }

        public static Release CreateFromReleaseData(Guid artistId, ReleaseData releaseData)
        {
            Release release = new Release
            {
                ReleaseId = releaseData.Id,
                Title = releaseData.Title,
                Status = releaseData.Status,
                Label = releaseData.Labelinfolist[0].Label.Name,
                NumberOfTracks = releaseData.Mediumlist.Trackcount
            };

            release.OtherArtists = releaseData.Artistcredit
                                              .Where(a => a.Artist.Id != artistId.ToString())
                                              .Select(a => new ReleaseArtist
                                              {
                                                  Id = a.Artist.Id,
                                                  Name = a.Artist.Name
                                              })
                                              .ToList();

            return release;
        }
    }
}
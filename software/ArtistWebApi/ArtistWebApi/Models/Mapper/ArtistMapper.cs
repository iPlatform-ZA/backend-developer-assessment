using ArtistWebApi.Models.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistWebApi.Models.Mapper
{
    /// <summary>
    /// Converts database objects to business objects
    /// </summary>
    public static class ArtistMapper
    {

        public static ArtistBO ConvertToArtistBO(Artist artist)
        {
            if (artist == null)
                return null;

            var result = new ArtistBO()
            {
                Country = artist.CountryCode,
                Id = artist.Id,
                Name = artist.Name
            };

            if (! String.IsNullOrEmpty(artist.Aliases))
            {
                result.Alias = artist.Aliases.Split(',').ToList();
            }

            return result;
        }

        public static IEnumerable<ArtistBO> ConvertToArtistBOList(IEnumerable<Artist> artists)
        {
            if (artists == null)
                return null;

            var result = new List<ArtistBO>();

            foreach (var artist in artists)
            {
                result.Add(ConvertToArtistBO(artist));
            }

            return result;
        }

        public static ReleasesBO ConvertToReleasesBO(IEnumerable<MusicBrainz.Data.ReleaseData> releasesList)
        {
            ReleasesBO result = new ReleasesBO();

            if ((releasesList != null) && (releasesList.Any()))
            {
                result.Releases = new List<ArtistReleaseBO>();

                foreach (var release in releasesList)
                {
                    ArtistReleaseBO artistReleaseBO = new ArtistReleaseBO()
                    {
                        ReleaseId = release.Id,
                        Title = release.Title,
                        Status = release.Status
                    };

                    if ((release.Labelinfolist != null) && (release.Labelinfolist.Any()) && (release.Labelinfolist.First().Label != null))
                    {
                        artistReleaseBO.Label = release.Labelinfolist.First().Label.Name;
                    }

                    artistReleaseBO.NumberOfTracks = (release.Mediumlist == null) ? 0 : release.Mediumlist.Trackcount;

                    if (release.Artistcredit != null && release.Artistcredit.Any())
                    {
                        artistReleaseBO.OtherArtists = new List<ArtistBaseBO>();
                        foreach (var artistCredit in release.Artistcredit)
                        {
                            if (artistCredit.Artist != null)
                            {
                                var other = new ArtistBaseBO()
                                {
                                    Id = artistCredit.Artist.Id,
                                    Name = artistCredit.Artist.Name
                                };

                                artistReleaseBO.OtherArtists.Add(other);
                            }
                        }
                    }

                    result.Releases.Add(artistReleaseBO);
                }
            }

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
    public static class ModelConversions
    {
        public static Release ToRelease(this MusicBrainsAPI.ServiceModels.Release musicBrainzRelease)
        {
            if (musicBrainzRelease == null)
            {
                return null;
            }

            var release = new Release();

            if (musicBrainzRelease.LabelInfoList != null)
            {
                release.Label = musicBrainzRelease.LabelInfoList.LabelInfo.FirstOrDefault().Labels.FirstOrDefault().Name;
            }
            else
            {
                release.Label = "";
            }

            release.NumberOfTracks = musicBrainzRelease.MediumList.TrackCount;

            if (musicBrainzRelease.ArtistCredit != null && musicBrainzRelease.ArtistCredit.NameCredits != null && musicBrainzRelease.ArtistCredit.NameCredits.Length > 0)
            {
                release.OtherArtists = musicBrainzRelease.ArtistCredit.NameCredits.Select(i => i.Artist.ToContributingArtist()).ToArray();
            }
            
            release.ReleaseId = musicBrainzRelease.ID;
            release.Status = musicBrainzRelease.Status;
            release.Title = musicBrainzRelease.Title;

            return release;
        }

        public static ContributingArtist ToContributingArtist(this MusicBrainsAPI.ServiceModels.Artist artist)
        {
            if (artist == null)
            {
                return null;
            }

            var contributingArtist = new ContributingArtist();

            contributingArtist.ID = artist.ID;
            contributingArtist.Name = artist.Name;

            return contributingArtist;
        }
    }
}
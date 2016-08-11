using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repositories
{
    // TODO: abstract out the MusicBrainzApi
    class ReleaseRepository : IReleaseRepository
    {
        public IEnumerable<Release> GetReleaseByArtistId(Guid id)
        {
            List<Release> returnValue = new List<Release>();

            // TODO: notify if error occurs
            var searchResponse = MusicBrainsAPI.MusicBrainz.GetReleasesByArtistId(id);

            if (searchResponse.Success)
            {
                returnValue = ConvertEnumerableOfMusicBrainzReleaseToWebApiRelease(searchResponse.Result, id);
            }

            return returnValue;
        }

        public IEnumerable<Release> GetAlbumsByArtistId(Guid id)
        {
            List<Release> returnValue = new List<Release>();

            Guid[] releaseIds = GetFirstReleaseIdFromAlbumReleaseGroupsByArtistId(id);

            if (releaseIds.Length == 0)
            {
                return returnValue;
            }

            // TODO: notify if error occurs
            var searchResponse = MusicBrainsAPI.MusicBrainz.GetReleasesByReleaseId(releaseIds);

            if (searchResponse.Success)
            {
                returnValue = ConvertEnumerableOfMusicBrainzReleaseToWebApiRelease(searchResponse.Result, id);
            }

            return returnValue;
        }

        private Guid[] GetFirstReleaseIdFromAlbumReleaseGroupsByArtistId(Guid artistId)
        {
            List<Guid> releaseIds = new List<Guid>();

            // TODO: notify if error occurs
            var searchResponse = MusicBrainsAPI.MusicBrainz.GetReleaseGroupsByArtistId(artistId);

            if (searchResponse.Success)
            {
                foreach (var releaseGroup in searchResponse.Result.Where(i => i.PrimaryType != null && i.PrimaryType.ToLower() == "album"))
                {
                    if (releaseGroup.ReleaseList.Releases.Any())
                    {
                        releaseIds.Add(releaseGroup.ReleaseList.Releases.Select(i => i.ID).First());
                    }
                }
            }

            return releaseIds.ToArray();
        }        

        private List<Release> ConvertEnumerableOfMusicBrainzReleaseToWebApiRelease(IEnumerable<MusicBrainsAPI.ServiceModels.Release> musicBrainzReleases, Guid albumArtistId) 
        {
            List<Release> returnValue = new List<Release>();

            foreach (var item in musicBrainzReleases)
            {
                var release = item.ToRelease();

                // remove the album artist from the list of contributing artists
                if (albumArtistId != Guid.Empty)
                {
                    release.OtherArtists = release.OtherArtists.Where(i => i.ID != albumArtistId).ToArray();
                }

                returnValue.Add(release);
            }

            return returnValue;
        }
    }
}

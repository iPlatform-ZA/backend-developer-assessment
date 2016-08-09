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
                foreach (var item in searchResponse.Result)
                {
                    var release = new Release();

                    if (item.LabelInfoList != null)
                    {
                        release.Label = item.LabelInfoList.LabelInfo.FirstOrDefault().Labels.FirstOrDefault().Name;
                    }
                    else
                    {
                        release.Label = "";
                    }

                    release.NumberOfTracks = item.MediumList.TrackCount;
                    release.ReleaseId = item.ID;
                    release.Status = item.Status;
                    release.Title = item.Title;

                    returnValue.Add(release);
                }
            }

            return returnValue;
        }
    }
}

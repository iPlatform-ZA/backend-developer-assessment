using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;

using Assessment.DataAccessLayer;
using Assessment.BusinessLogic.Contracts;
using Assessment.BusinessLogic.Common;
using Assessment.Models.DTO;
using Assessment.Models.ThirdParty.MusicBrainz;

namespace Assessment.BusinessLogic.Implementations
{
    public class Artist<T> : IArtist
    {
        public async Task<ResultDTO<ArtistDTO>> GetArtists(string searchCriteria, int pageNumber, int pageSize)
        {
            ResultDTO<ArtistDTO> result = new ResultDTO<ArtistDTO>();

            try
            {
                result.Page = pageNumber;
                result.PageSize = pageSize;

                /*
                    Please read:
                 
                    Here's my take on the following text in the instructions on GitHub...
                    The first statement reads: "/artist/search/joh should return John Coltrane, John Mayer, Johnny Cash, Elton John and John Frusciante"
                    Later on it reads: "The search should return all artist whose name or alias >STARTS WITH< the search criteria."
                    
                    If I use the Contains() method, it will produce the desired result (+ an ommited result "Jack Johnson") since it matches "Joh" anywhere in the name of the Artist
                    If I use the StartsWith() method, it will only produce results where the name of the Artists begins with "Joh", which would exlude Elton John for example.
                    
                    Conclusion: They are mutually exclusive, went with Contains() in this case as it's a more versatile method of searching from a user's perspective.
                */

                var context = new AssessmentEntities();
                var query = from av in context.ArtistsViews
                            where av.Name.Contains(searchCriteria) || av.Alias.Contains(searchCriteria)
                            select av;

                result.NumberOfSearchResults = query
                    .GroupBy(x => x.ArtistID)
                    .Select(y => y.FirstOrDefault())
                    .Count();

                List<ArtistsView> artists = query
                    .GroupBy(y => y.ArtistID)
                    .Select(z => z.FirstOrDefault())
                    .OrderBy(x => x.ArtistID)
                    .Skip(((pageNumber == 0) ? pageNumber : (pageNumber * pageSize)))
                    .Take(pageSize)
                    .ToList<ArtistsView>();

                result.Page = pageNumber + 1;
                result.NumberOfPages = Math.Ceiling(Convert.ToDouble(result.NumberOfSearchResults) / Convert.ToDouble(pageSize));
                result.NumberOfPages = (result.NumberOfPages == 0) ? 1 : result.NumberOfPages;

                List<ArtistDTO> list = new List<ArtistDTO>();

                foreach (ArtistsView artist in artists)
                {
                    ArtistDTO item = new ArtistDTO();

                    item.Name = artist.Name;
                    item.Country = artist.Country;
                    item.Alias = GetArtistAliases(artist.ArtistID);
                    item.Albums = await GetArtistAlbums(artist.UniqueIdentifier.ToString());

                    list.Add(item);
                }

                result.results = list;
            }
            catch (Exception ex)
            {
                result = new ResultDTO<ArtistDTO>();
                Logger.LogEvent(ex.ToString());
            }

            return result;
        }

        public async Task<List<AlbumDTO>> GetArtistAlbums(string id)
        {
            List<AlbumDTO> albums = new List<AlbumDTO>();

            try
            {
                MBArtistReleaseDTO result = await MusicBrainz.GetArtistsReleases(id);

                if (result.releases != null) { 
                    foreach (MBReleaseDTO release in result.releases)
                    {
                        AlbumDTO album = new AlbumDTO();

                        album.ID = release.id;
                        album.Title = release.title;
                        album.ReleaseDate = release.date;
                        album.Link = ConfigurationManager.AppSettings["MusicBrainzReleaseURI"].ToString() + release.id;

                        albums.Add(album);
                    }
                }
            }
            catch (Exception ex)
            {
                albums = new List<AlbumDTO>();
                Logger.LogEvent(ex.ToString());
            }

            return albums;
        }

        public async Task<List<AlbumDTO>> GetAlbumInfo(string id)
        {
            List<AlbumDTO> albums = new List<AlbumDTO>();

            try
            {
                MBArtistReleaseDTO result = await MusicBrainz.GetArtistsReleases(id);

                foreach (MBReleaseDTO release in result.releases)
                {
                    AlbumDTO album = new AlbumDTO();

                    album.Title = release.title;
                    album.ReleaseDate = release.date;
                    album.Link = ConfigurationManager.AppSettings["MusicBrainzReleaseURI"].ToString() + release.id;

                    albums.Add(album);
                }
            }
            catch (Exception ex)
            {
                albums = new List<AlbumDTO>();
                Logger.LogEvent(ex.ToString());
            }

            return albums;
        }

        public async Task<ResultDTO<ReleaseInfoDTO>> GetArtistReleases(string id)
        {
            ResultDTO<ReleaseInfoDTO> albums = new ResultDTO<ReleaseInfoDTO>();
            albums.results = new List<ReleaseInfoDTO>();

            try
            {
                MBArtistReleaseDTO artistReleaseInfo = await MusicBrainz.GetArtistsReleases(id);

                int count = 0;

                foreach (MBReleaseDTO release in artistReleaseInfo.releases)
                {
                    count++;

                    MBReleaseInfoDTO releaseInfo = await MusicBrainz.GetReleaseInfo(release.id);
                    ReleaseInfoDTO item = new ReleaseInfoDTO();

                    item.releaseID = release.id;
                    item.label = (releaseInfo.labelinfo.Count() > 0) ? releaseInfo.labelinfo[0].label.name : "";
                    item.status = release.status;
                    item.title = release.title;
                    item.numberOfTracks = (releaseInfo.media.Count() > 0) ? releaseInfo.media[0].trackcount : 0;

                    item.otherArtists = new List<ArtistCreditDTO>();

                    foreach (MBArtistCreditDTO credit in releaseInfo.artistcredit)
                    {
                        ArtistCreditDTO artistCredit = new ArtistCreditDTO();

                        artistCredit.id = credit.artist.id;
                        artistCredit.name = credit.name;

                        item.otherArtists.Add(artistCredit);
                    }

                    albums.results.Add(item);

                    if (count == 10) break;
                }

                albums.Page = 1;
                albums.PageSize = 10;
                albums.NumberOfSearchResults = 10;
                albums.NumberOfPages = 1;
            }
            catch (Exception ex)
            {
                albums = new ResultDTO<ReleaseInfoDTO>();
                Logger.LogEvent(ex.ToString());
            }

            return albums;
        }

        public List<string> GetArtistAliases(long id)
        {
            List<string> list = new List<string>();

            try
            {
                var context = new AssessmentEntities();
                var query = from x in context.ArtistAliases where x.ArtistID == id select x;

                List<ArtistAlias> aliases = query.ToList<ArtistAlias>();

                foreach (ArtistAlias artistAlias in aliases)
                {
                    list.Add(artistAlias.Alias);
                }
            }
            catch (Exception ex)
            {
                list = new List<string>();
                Logger.LogEvent(ex.ToString());
            }

            return list;
        }
    }
}

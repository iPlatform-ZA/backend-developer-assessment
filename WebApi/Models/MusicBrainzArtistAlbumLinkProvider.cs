using System.Text.RegularExpressions;
using WebApi.Interfaces;

namespace WebApi.Models
{
    /// <summary>
    /// This class creates a link that poits to a page on the MusicBrainz website which lists the albums of the given atrist
    /// </summary>
    public class MusicBrainzArtistAlbumLinkProvider : IArtistAlbumLinkProvider
    {
        // the base url for the MusicBrainz website.         
        private string _musicBrainzArtistAlbumsBaseUrl; 

        public string MusicBrainzArtistAlbumsBaseUrl
        {
            get { return _musicBrainzArtistAlbumsBaseUrl; }
        }

        public MusicBrainzArtistAlbumLinkProvider()
        {
            _musicBrainzArtistAlbumsBaseUrl = StripTrailingSlashes("http://musicbrainz.org/artist/");
        }

        public MusicBrainzArtistAlbumLinkProvider(string baseUrlForMusicBrainzArtistAlbums)
        {
            // TODO: Add validation
            _musicBrainzArtistAlbumsBaseUrl = StripTrailingSlashes(baseUrlForMusicBrainzArtistAlbums);
        }

        /// <summary>
        ///     Creates the URL to the specified artist on the the MusicBrainz web site
        /// </summary>
        /// <param name="aritstIdentifier">The artist ID used by MusicBrainz (Guid)</param>
        /// <returns>A string</returns>
        public string GetLinkToArtistAlbums<Guid>(Guid aritstIdentifier)
        {
            return $"{_musicBrainzArtistAlbumsBaseUrl}/{aritstIdentifier}";
        }

        private string StripTrailingSlashes(string inputString)
        {
            if (inputString == null)
                return null;

            return Regex.Replace(inputString, @"/+$", "");
        }
    }
}

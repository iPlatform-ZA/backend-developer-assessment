using ArtistDAL.Models;

namespace ArtistApi.Models
{
    public class SearchResultArtist
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string[] Aliases { get; set; }

        public static SearchResultArtist CreateFromArtist(Artist artist)
        {
            return new SearchResultArtist
            {
                Name = artist.Name,
                Country = artist.Country,
                Aliases = !string.IsNullOrEmpty(artist.Aliases)
                            ? artist.Aliases.Split(',')
                            : new string[0]
            };
        }
    }
}
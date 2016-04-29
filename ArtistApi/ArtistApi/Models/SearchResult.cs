using System.Collections.Generic;

namespace ArtistApi.Models
{
    public class SearchResult
    {
        public int NumberOfSearchResults { get; set; }
      
        public int Page { get; set; }
      
        public int PageSize { get; set; }
          
        public int NumberOfPages { get; set; }

        public IEnumerable<SearchResultArtist> Results { get; set; }
    }
}
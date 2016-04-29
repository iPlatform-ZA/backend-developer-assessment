using System;
using System.Collections.Generic;
using System.Linq;

using ArtistDAL.Models;

namespace ArtistApi.Models
{
    public class SearchResult
    {
        public SearchResult(IQueryable<Artist> artists, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;

            NumberOfSearchResults = artists.Count();

            Results = artists.Skip(PageOffset)
                             .Take(PageSize)
                             .ToList()
                             .Select(artist => SearchResultArtist.CreateFromArtist(artist));
        }
        
        public int NumberOfSearchResults { get; set; }
      
        public int PageNumber { get; set; }
      
        public int PageSize { get; set; }
          
        public int NumberOfPages
        {
            get { return (int)Math.Ceiling((double)NumberOfSearchResults / PageSize); }
        }
        
        public IEnumerable<SearchResultArtist> Results { get; set; }

        private int PageOffset
        {
            get { return PageSize * (PageNumber - 1); }
        }
    }
}
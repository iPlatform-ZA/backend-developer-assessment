using System;
using System.Collections.Generic;
using System.Linq;

using ArtistDAL.Models;

namespace ArtistApi.Models
{
    public class SearchResult
    {
        private IQueryable<Artist> artists;

        public SearchResult(IQueryable<Artist> artists, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;

            this.artists = artists;
        }

        public int NumberOfSearchResults
        {
            get { return artists.Count(); }
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int NumberOfPages
        {
            get { return (int)Math.Ceiling((double)NumberOfSearchResults / PageSize); }
        }

        public IEnumerable<SearchResultArtist> Results
        {
            get
            {
                return artists.Skip(PageOffset)
                              .Take(PageSize)
                              .ToList()
                              .Select(artist => SearchResultArtist.CreateFromArtist(artist));
            }
        }

        private int PageOffset
        {
            get { return PageSize * (PageNumber - 1); }
        }
    }
}
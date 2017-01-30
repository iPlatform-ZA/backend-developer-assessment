using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Helpers;

namespace ClassLib.Models
{
    public class SearchResults
    {

        public SearchResults(string artist, string pageNumber, string pageSize)
        {
            _artist = artist;
            _page = pageNumber;
            _pageSize = pageSize;
            _results = APIHelper.SearchForArtist(_artist);
            _numberOfSearchResults = _results.Count.ToString();
            _numberOfPages = (Convert.ToInt32(_numberOfSearchResults) / Convert.ToInt32(_pageSize)).ToString();
        }

        private void Initialize()
        {
            
        }
        
        private List<ArtistModel> _results;
        private string _artist;
        private string _numberOfSearchResults;
        private string _page;
        private string _pageSize;
        private string _numberOfPages;


        public List<ArtistModel> Results
        {
            get { return _results; }
            set { _results = value; }
        }

        public string NumberOfSearchResults
        {
            get { return _numberOfSearchResults; }
            set { _numberOfSearchResults = value; }
        }

        public string Page
        {
            get { return _page; }
            set { _page = value; }
        }

        public string PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public string NumberOfPages
        {
            get { return _numberOfPages; }
            set { _numberOfPages = value; }
        }
    }
}

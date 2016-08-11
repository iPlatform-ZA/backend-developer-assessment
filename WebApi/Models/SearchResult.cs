using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Models
{
    // This class should ideally be made abstract. Specific search result objects can then inherit from it.

    public class SearchResult<T>
    {
        private IEnumerable<T> _allItems;
        private IEnumerable<T> _results;
        private int _page = 1; 
        private int _pageSize = 10;
        private int _totaltemCount;
        private int _numberOfPages;

        /// <summary>
        /// The items of the current page
        /// </summary>
        public IEnumerable<T> Results
        {
            get
            {
                return _results;
            }
        }
        
        /// <summary>
        /// The total number of items found
        /// </summary>
        public int NumberOfSearchResults
        {
            get
            {
                return _totaltemCount;
            }
        }
        
        /// <summary>
        /// The current page
        /// </summary>
        public int Page
        {
            get
            {
                return _page;
            }
        }

        /// <summary>
        /// The number of items per page
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                SetPageSize(value, true);
            }
        }

        /// <summary>
        /// The number of pages of the size specified by PageSize for the given search result
        /// </summary>
        public int NumberOfPages
        {
            get
            {
                return _numberOfPages;
            }
        }

        public SearchResult(IEnumerable<T> items) :this(items, 10, 1)
        {            
        }

        public SearchResult(IEnumerable<T> items, int pageSize): this(items, pageSize, 1)
        {            
        }

        public SearchResult(IEnumerable<T> items, int pageSize, int page)
        {
            _allItems = items;

            if (_allItems == null)
            {
                _totaltemCount = 0;
            }
            else
            {
                _totaltemCount = items.Count();
            }

            SetPageSize(pageSize, false);
            GoToPage(page);
        }

        /// <summary>
        /// Goes to the requested page. 
        /// If the requested page is less than 1, page 1 is returned.
        /// If the requested page is higher than the total number of pages, the last page is returned
        /// </summary>
        /// <param name="pageNumber"></param>
        public void GoToPage(int pageNumber)
        {
            if (_allItems == null)
            {
                _page = 1;
                _results = null;
                return;
            }

            if (pageNumber < 1)                
            {
                _page = 1;
            }
            else if (pageNumber > _numberOfPages)
            {
                _page = _numberOfPages;
            }
            else
            {
                _page = pageNumber;
            }

            _results = _allItems.Skip(_pageSize * (_page - 1)).Take(_pageSize);
        }

        private void SetPageSize(int pageSize, bool updateResults)
        {
            if (pageSize > 0)
            {
                _pageSize = pageSize;
                CalculateNumberOfPages();                
            }
            else
            {
                throw new ArgumentException("Invalid. Must be greater than 0.", "PageSize");
            }

            if (updateResults)
            {
                GoToPage(_page);
            }
        }

        private void CalculateNumberOfPages()
        {
            _numberOfPages = (int)Math.Ceiling((decimal)_totaltemCount / (decimal)_pageSize);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend_Assessment.Paging
{
    public class PagedList<T>
    {
        private int _pageNumber;
        private int _pageSize;
        private IEnumerable<T> _data;

        public PagedList(IEnumerable<T> data, int pageNumber, int pageSize)
        {
            _data = data;
            _pageNumber = pageNumber;
            _pageSize = pageSize;
        }

        public IEnumerable<T> Results { get { return new PagedList.PagedList<T>(_data, Page, PageSize); } }
        
        private bool IsFirstPage { get { return _pageNumber == 1; } }
        public int NumberOfSearchResults { get { return _data.Count(); } }
        public int Page { get { return _pageNumber; } }
        public int PageSize { get { return _pageSize; } }
        public double NumberOfPages { get { return Math.Ceiling((double)NumberOfSearchResults / _pageSize); } }
        
    }
}
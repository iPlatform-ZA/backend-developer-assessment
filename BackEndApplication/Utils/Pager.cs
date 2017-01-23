using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndApplication.Utils
{
    public class Pager
    {
        private int _totalRecords;

        private int _pageNumber;

        private int _pageSize;

        private int _offset;

        private int _pageCount;

        public Pager(int totalRecords, int pageNumber, int pageSize)
        {
            this._totalRecords = totalRecords;

            this._pageNumber = pageNumber < 1 ? 1 : pageNumber;

            this._pageSize = pageSize < 1 ? 10 : pageSize;

            Initalise();
        }
        
        private void Initalise() 
        {
            //set page number if expexted pages > total records
            if (_pageSize * _pageNumber > _totalRecords)
            {
                _pageNumber = 1;
            }

            //offset
            _offset = CalcualteOffset();

            //page count
           _pageCount =  CaclculatePageCount();


        }

        private int CaclculatePageCount()
        {
            if(_totalRecords <=0 ) return 1;

            int count = _totalRecords / _pageSize;

            if (_totalRecords % _pageSize > 0) count++;

            return count;
        }

        private int CalcualteOffset()
        {
            return (_pageNumber - 1) * _pageSize;
        }

        public int TotalRecords
        {
            get { return _totalRecords; }
        }

        public int PageSize
        {
            get { return _pageSize; }
        }

        public int PageNumber
        {
            get { return _pageNumber; }
        }

        public int PageCount
        {
            get { return _pageCount; }
        }

        public int Offset
        {
            get { return _offset; }
        }

    }
}
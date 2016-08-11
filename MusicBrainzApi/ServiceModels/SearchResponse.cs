using System;

namespace MusicBrainsAPI.ServiceModels
{
    public class SearchResponse<T>
    {
        private T[] _resultArray;

        public SearchResponse()
        {
            _resultArray = new T[0];
        }

        public T[] Result
        {
            get { return _resultArray; }
            set { _resultArray = value; }
        }

        public bool Success { get; set; }

        public String Error { get; set; }
    }
}

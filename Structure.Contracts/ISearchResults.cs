namespace Structure.Contracts
{
    using System.Collections.Generic;
    public class PagedResultSet<T>
    {
        public IEnumerable<T> Results { get; set; }

        public int NumberOfSearchResults { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int NumberOfPages { get; set; }
    }
}

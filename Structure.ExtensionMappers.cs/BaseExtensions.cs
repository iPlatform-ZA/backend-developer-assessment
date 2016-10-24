
namespace Structure
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public static class BaseExtensions
    {
        public static PagedResultSet<T> ApplyPaging<T>(this IQueryable<T> query,
            PagingArgs pageArgs, Expression<Func<T, string>> orderBy)
        {
            if (pageArgs == null)
            {
                throw new ArgumentNullException("pageArgs");
            }

            var totalNumberOfRecords = query.Count();

            var pageNumber = pageArgs.CalculatePageNumber(totalNumberOfRecords);
            var recordsToSkip = (pageNumber - 1) * pageArgs.Page_Size;

            var pagedQuery = query
                .OrderBy(orderBy)
                .Skip(recordsToSkip)
                .Take(pageArgs.Page_Size);

            return new PagedResultSet<T>
            {
                Results = pagedQuery,
                Page = pageNumber,
                PageSize = pageArgs.Page_Size,
                NumberOfSearchResults = totalNumberOfRecords,
                NumberOfPages = (int)Math.Floor((double)(totalNumberOfRecords / pageArgs.Page_Size)) + 1
            };

        }

        private static int CalculatePageNumber(this PagingArgs pageArgs, int totalNumberOfRecords)
        {
            var lastPageNumber = (int)Math.Floor((double)(totalNumberOfRecords / pageArgs.Page_Size)) + 1;

            var isRequestedPageBeyondLastPage = pageArgs.Page_Number > lastPageNumber;
            if (isRequestedPageBeyondLastPage)
            {
                return lastPageNumber;
            }

            return pageArgs.Page_Number;
        }
    }
}

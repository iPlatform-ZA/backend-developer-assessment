using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackEndApplication.Utils;

namespace BackEndApplication.Models
{
    public class ArtistRepository : IDisposable, IArtistRepository
    {
        private bool disposed = false;

        private BackEndDataContext context = new BackEndDataContext();
        
        public PagedResult<Artist> Search(string searchCriteria, int pageNumber, int pageSize)
        {
            var totalRecords = context.Artists.Where(x => x.ArtistName.Contains(searchCriteria)).Count();

            Pager pager = new Pager(totalRecords, pageNumber, pageSize);

            var artists = context.Artists.Where(x => x.ArtistName.Contains(searchCriteria))
                    .OrderBy(x => x.ArtistName)
                    .Skip(pager.Offset)
                    .Take(pageSize).ToList();

            return new PagedResult<Artist>
            {
                results = artists,
                numberOfSearchResults = pager.TotalRecords,
                page = pager.PageNumber,
                pageSize = pager.PageSize,
                numberOfPages = pager.PageCount
            }; 

        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
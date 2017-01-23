using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndApplication.Utils
{
    public class PagedResult<TEntity> where TEntity : class
    {
        public List<TEntity> results { get; set; }
        public int numberOfSearchResults { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int numberOfPages { get; set; }
    }
}
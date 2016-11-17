using BackendDeveloperAssessment.IRepository.IUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperAssessment.Repository.Utilities
{
    public class PagerUtility<T> : IPagerUtility<T>
    {
        public IEnumerable<T> GetPageItems(List<T> queryList, int pageNumber, int pageSize)
        {
            if (queryList == null) return null;
            return queryList.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

    }
}

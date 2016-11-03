using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperAssessment.IRepository.IUtilities
{
    public interface IPagerUtility<T>
    {
        IEnumerable<T> GetPageItems(List<T> queryList, int pageNumber, int pageSize);
    }
}

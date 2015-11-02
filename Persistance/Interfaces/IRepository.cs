using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public interface IRepository<T>
    {
        IQueryable<T> GetArtists(Expression<Func<T, bool>> filter);
        T GetArtistById(int Id);
    }
}

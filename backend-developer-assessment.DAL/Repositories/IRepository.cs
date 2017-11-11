using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace backend_developer_assessment.DAL.Repositories
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Get(object id);
        void Add(T entity);
        void Update(T entity);
        void Remove(object id);
        void Remove(T entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace backend_developer_assessment.DAL.Repositories
{
    public abstract class Repository<T> : IRepository<T>  where T : class 
    {
        protected readonly ApplicationDbContext db;
        public Repository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return  db.Set<T>().Where(predicate);
        }

        public T Get(object id)
        {
            return db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public void Remove(object id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

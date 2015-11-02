using Domain;
using Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal IDbSet<T> dbset;
        internal IBEContext _context;

        public Repository(IBEContext context)
        {
            _context = context;
            dbset = _context.Set<T>();
        }

        public IQueryable<T> GetArtists(System.Linq.Expressions.Expression<Func<T, bool>> filter )
        {
            try
            {
                IQueryable<T> query = dbset;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                return query;
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public T GetArtistById(int Id)
        {
            var o = dbset.Find(Id);
            
            return o;
        }
    }
}

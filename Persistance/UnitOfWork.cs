using Persistance.Interfaces;
using System;
//using System.Data.Entity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public  sealed class UnitOfWork : IUnitOfWork
    {        
        private IBEContext context;
        private Hashtable repositories;


        public UnitOfWork(IBEContext context)
        {
            this.context = context;
        }
        public int Commit()
        {
            return context.SaveChanges();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories == null)
                repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repoType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repoType.MakeGenericType(typeof(T)), context);

                repositories.Add(type, repositoryInstance);
            }

            return (IRepository <T>) repositories[type];
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }
    }
}

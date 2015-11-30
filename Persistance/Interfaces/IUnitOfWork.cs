using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        IRepository<T> Repository<T>() where T : class;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IArtistRepository Artists { get; }
        int Complete();
    }
}

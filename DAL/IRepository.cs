using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository
    {
        IQueryable<Artist> All { get; }
        IQueryable<Artist> Search(string searchStr);
        Artist GetOne(string id);
    }
}

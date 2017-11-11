using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend_developer_assessment.DAL.Repositories;
using backend_developer_assessment.Entities;

namespace backend_developer_assessment.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        private IArtistRepository _artistRepository;
        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }

        public IArtistRepository AritstRepository
        {
            get {
                return _artistRepository = _artistRepository ?? new ArtistRepository(_context);
            }
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}

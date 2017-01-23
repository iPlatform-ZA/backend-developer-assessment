using MusicBrainz.Platform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainz.Data
{
    public class UnitOfWork : IDisposable
    {
        private MusicBrainzContext context = new MusicBrainzContext();
        private GenericRepository<Artist> _artistRepository;

        public GenericRepository<Artist> ArtistRepository
        {
            get
            {
                if (_artistRepository == null)
                {
                    _artistRepository = new GenericRepository<Artist>(context);
                }
                return _artistRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using Backend.Assessment.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Assessment.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IArtistRepository Artists
        {
            get; private set;
        }

        private readonly BackendContext Context;

        public UnitOfWork(BackendContext context)
        {
            Context = context;
            Artists = new ArtistRepository(Context);
        }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
using BackendDeveloperAssessment.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperAssessment.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private BackendDeveloperAssessmentDbContext DbContext;

        public UnitOfWork()
        {
            CreateDbContext();
        }
        private void CreateDbContext()
        {
            DbContext = new BackendDeveloperAssessmentDbContext();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}

using BackendDeveloperAssessment.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperAssessment.Repository
{
    public class BackendDeveloperAssessmentDbContext : DbContext
    {
        public BackendDeveloperAssessmentDbContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Aliases> Alias { get; set; }

    }
}

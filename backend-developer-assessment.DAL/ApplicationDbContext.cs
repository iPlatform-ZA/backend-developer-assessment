using backend_developer_assessment.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_developer_assessment.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Artist> Artist { get; set; }
        public ApplicationDbContext()
            : base("name=AppConnection")
        {
        }
    }
}

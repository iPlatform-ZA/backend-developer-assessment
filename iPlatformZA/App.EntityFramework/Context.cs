using App.EntityFramework.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EntityFramework
{   
    /// <summary>
    /// Entity Framework Context Class for the Database.
    /// </summary>
    public class Context : System.Data.Entity.DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public Context() : base("Name=AppConnectionString")
        {
        }
        static Context()
        {
            Database.SetInitializer<Context>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

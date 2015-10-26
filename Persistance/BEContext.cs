using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.Entity.ModelConfiguration.Conventions;
using Persistance.Interfaces;

namespace Persistance
{
    public class BEContext : DbContext, IBEContext
    {
        public BEContext()
            : base("BEContext")
        {

        }
        
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Elias> Eliases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public new virtual IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}

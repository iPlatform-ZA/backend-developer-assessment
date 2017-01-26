using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApCore.Entities;

namespace WebAp.Infrastructure
{
    public class ArtistContext : DbContext
    {
        public ArtistContext() : base("name=ArtistConnection")
        {

        }
        public IDbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

    }
}
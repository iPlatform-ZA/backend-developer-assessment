using BackendApi.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BackendApi.Models
{
    public class ArtistContext : DbContext, IDbContext
    {
        public ArtistContext() : base("name=ArtistsConn")
        {
            Database.SetInitializer<ArtistContext>(new ArtistInializer<ArtistContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Artist>()
                .HasKey(x => x.Id);
        }

        IDbSet<T> IDbContext.Set<T>()
        {
            return base.Set<T>();
        }

    }
}
namespace Backend.Assessment.Context
{
    using Models;
    using System.Data.Entity;


    public partial class BackendContext : DbContext
    {
        public BackendContext()
            : base("name=BackendContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Album_Artist> Album_Artist { get; set; }
        public virtual DbSet<Alias> Aliases { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .HasMany(e => e.Album_Artist)
                .WithRequired(e => e.Album)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artist>()
                .Property(e => e.CountryIso)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Artist>()
                .HasMany(e => e.Album_Artist)
                .WithRequired(e => e.Artist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artist>()
                .HasMany(e => e.Aliases)
                .WithRequired(e => e.Artist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.Iso)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.Iso3)
                .IsFixedLength()
                .IsUnicode(false);

            Database.SetInitializer<BackendContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}

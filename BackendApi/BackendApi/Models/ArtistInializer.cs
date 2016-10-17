using System;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace BackendApi.Models
{
    internal class ArtistInializer<T> : CreateDatabaseIfNotExists<ArtistContext>
    {
        protected override void Seed(ArtistContext context)
        {
            var sqlCommandsFiles = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data"), "*.sql")
                .Select(s => s);
            foreach (var file in sqlCommandsFiles)
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(file));
            }
            base.Seed(context);
        }
    }
}
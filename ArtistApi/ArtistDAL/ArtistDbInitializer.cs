using System.Data.Entity;
using System.IO;
using System.Web.Hosting;

namespace ArtistDAL
{
    public class ArtistDbInitializer :
        DropCreateDatabaseIfModelChanges<ArtistContext>
    {
        protected override void Seed(ArtistContext context)
        {
            string scriptPath = string.Format(@"{0}bin\Scripts\Artists.sql", HostingEnvironment.ApplicationPhysicalPath);

            foreach (string sql in File.ReadLines(scriptPath))
            {
                context.Database.ExecuteSqlCommand(sql);
            }
        }
    }
}

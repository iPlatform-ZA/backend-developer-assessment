using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iPlatform_ZA.Models
{
    public class iPlatform_ZAContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public iPlatform_ZAContext() : base("name=iPlatform_ZAContext")
        {
        }

        public System.Data.Entity.DbSet<iPlatform_ZA.Models.Artist> Artists { get; set; }
    }
}

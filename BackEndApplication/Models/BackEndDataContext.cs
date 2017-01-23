using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BackEndApplication.Models
{
    public class BackEndDataContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
    }
}
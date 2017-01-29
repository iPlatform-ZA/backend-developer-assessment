using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApCore.Entities
{
    public class Artist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Aliases { get; set; }
    }
}
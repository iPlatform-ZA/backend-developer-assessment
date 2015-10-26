using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Artist
    {
        public Artist()
        {
            Eliases = new List<Elias>();
        }

        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Elias> Eliases { get; set; }
    }
}

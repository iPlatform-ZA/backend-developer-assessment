using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ArtistModel
    {
        //public System.Guid ID { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public List<String> alias { get; set; }
    }
}

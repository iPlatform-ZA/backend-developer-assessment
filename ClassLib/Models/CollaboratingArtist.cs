using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Abstract;

namespace ClassLib.Models
{
    public class CollaboratingArtist:CollaboratingArtistBase
    {
        public CollaboratingArtist(string id, string name) : base(id, name)
        {
        }
    }
}

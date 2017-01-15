using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Abstract;
using ClassLib.Data;

namespace ClassLib.Models
{
    public class ArtistModel:ArtistsBase
    {
        public ArtistModel(Artist artists) : base(artists)
        {

        }
    }
}

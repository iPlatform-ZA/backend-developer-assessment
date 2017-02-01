using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public interface IModelFactory
    {
        ArtistModel Create(Artist artist);
    }
    public class ModelFactory : IModelFactory
    {
        public ArtistModel Create(Artist artist)
        {
            return new ArtistModel
            {               
                name = artist.Name,
                country = artist.Country,
                alias = artist.Alias.Select(a => a.Name).ToList()
            };
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Abstract;
using ClassLib.Data;
using ClassLib.Factories;
using ClassLib.interfaces;
using ClassLib.Models;

namespace ClassLib.Helpers
{
    public static class APIHelper
    {
        public static List<ArtistModel> SearchForArtist(string artist)
        {
            List<ArtistModel> artists = new List<ArtistModel>();
            ArtistsFactory<IArtist,ArtistModel> artFact = new ArtistsFactory<IArtist, ArtistModel>();
            using (ArtistsEntities artistsEntities = new ArtistsEntities())
            {
                if (artistsEntities.Artists.Any(x => x.ArtistsName.Contains(artist)))
                {
                    foreach (var source in artistsEntities.Artists.Where(x=>x.ArtistsName.Contains(artist)))
                    {
                        artists.Add(artFact.GetObject(source));
                    }
                }
            }

            return artists;
        }
    }
}

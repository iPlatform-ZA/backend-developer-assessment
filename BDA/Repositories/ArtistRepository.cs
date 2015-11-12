using BDA.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BDA.Context;
using BDA.Models;


namespace BDA.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        ArtistsEntities context;
        public ArtistRepository()
        {

            context = new ArtistsEntities();
        }

        public IEnumerable<Models.ArtistModel> GetAll()
        {
            var artists = context.Artists.ToList();

            var artistResult = ConvertToArtistModelList(artists);
            return artistResult;
        }


        public IEnumerable<ArtistModel> Search(string searchCriteria, int pageNumber, int pageSize)
        {
            var pageing = pageSize * pageNumber - pageSize;
            var artists = context.Artists.Where(artist => artist.ArtistName.Contains(searchCriteria))
                .OrderBy(artist => artist.ArtistName)
                .Skip(pageing)
                .Take(pageSize)
                .ToList();

            var artistResult = ConvertToArtistModelList(artists);
            return artistResult;
        }

        private List<ArtistModel> ConvertToArtistModelList(List<Artist> artists)
        {
            
            var artistResult = new List<ArtistModel>();
            foreach (var artist in artists)
            {
                var artistModel = new ArtistModel()
                {
                    ArtistName = artist.ArtistName,
                    Country = artist.Country,
                    Id = artist.Id,
                    UniqueIdentifier = artist.UniqueIdentifier,
                    Aliases = artist.Aliases.Split(',').ToList()
                };
                artistResult.Add(artistModel);
            }
            return artistResult;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Interfaces;
using WebApi.Repositories.RepositoryModels;

namespace WebApi.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        public Artist GetById(Guid id)
        {
            using (var _dbContext = new ArtistInfoDataAccess.ArtistInfoEntities())
            {
                var artist = _dbContext.Artists.Where(i => i.Id == id).FirstOrDefault();

                var retVal = new Artist()
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Country = artist.Country.Code,
                    Alias = artist.ArtistAlias.Select(a => a.Alias).ToArray()
                };

                return retVal;
            }
        }

        public IEnumerable<Artist> FindByNameOrAlias(string nameOrAlias)
        {
            using (var _dbContext = new ArtistInfoDataAccess.ArtistInfoEntities())
            {
                var artisists = _dbContext.Artists.Where(i => i.Name.ToLower().StartsWith(nameOrAlias.ToLower()) || i.ArtistAlias.Any(a => a.Alias.ToLower().StartsWith(nameOrAlias.ToLower())))
                    .Select(i => i);

                var retVal = artisists.ToList().ConvertAll(i => new Artist()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Country = i.Country.Code,
                    Alias = i.ArtistAlias.Select(a => a.Alias).ToArray()
                });

                return retVal;
            }            
        }
    }
}
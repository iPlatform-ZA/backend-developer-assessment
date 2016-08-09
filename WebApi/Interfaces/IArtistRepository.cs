using System;
using System.Collections.Generic;
using WebApi.Repositories.RepositoryModels;

namespace WebApi.Interfaces
{
    public interface IArtistRepository: IGenericRepository<Artist>
    {
        IEnumerable<Artist> FindByNameOrAlias(string nameOrAlias);

        Artist GetById(Guid id);
    }
}

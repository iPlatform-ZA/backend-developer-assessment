using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IArtistFactory
    {
        IEnumerable<CompositeArtist> FindByNameOrAlias(string nameOrAlias);

        CompositeArtist GetById(Guid id);
    }
}

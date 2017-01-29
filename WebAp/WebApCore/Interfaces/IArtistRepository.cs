using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAp.Core.Dto;
using WebApCore.Entities;

namespace WebApCore.Interfaces
{
    public interface IArtistRepository
    {
        IQueryable<Artist> search();
        IQueryable<Artist> search(string artistName);

        Artist GetArtist(Guid artistID);

    }
}

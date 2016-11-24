using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Backend.Assessment.Models;
using Backend.Assessment.Context;

namespace Backend.Assessment.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public BackendContext BackendContext
        {
            get { return Context as BackendContext; }
        }

        public AlbumRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Album> GetByArtistId(Guid artistId)
        {
            return (from album in BackendContext.Albums
                    join albumArtist in BackendContext.Album_Artist on album.Id equals albumArtist.AlbumId
                    join artist in BackendContext.Artists on albumArtist.ArtistId equals artist.Id
                    where artist.Id == artistId
                    select album).Take(10);
        }
    }
}
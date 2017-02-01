using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ArtistRepository : IRepository
    {
        private MusicEntities _context;
        public ArtistRepository(MusicEntities context)
        {
            _context = context;
        }
        public IQueryable<Artist> All
        {
            get
            {
                return _context.Artist;
            }
        }

        public Artist GetOne(string id)
        {
            return _context.Artist.Where(x => x.ID.ToString().Equals(id)).FirstOrDefault();
        }

        public IQueryable<Artist> Search(string searchStr)
        {
            if(!string.IsNullOrEmpty(searchStr))
            {
                return  from artist in _context.Artist
                            where artist.Name.StartsWith(searchStr) ||
                            artist.Alias.Any(a => a.Name.StartsWith(searchStr))
                            select artist;
            }
            return All;
        }
       
    }
}

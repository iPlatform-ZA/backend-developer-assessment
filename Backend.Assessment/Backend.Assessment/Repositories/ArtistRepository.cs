using System.Collections.Generic;
using System.Data.Entity;
using Backend.Assessment.Models;
using Backend.Assessment.Context;
using System.Linq;


namespace Backend.Assessment.Repositories
{
    //Repository Layer and Unit of Work used to facilitate integration, unit testing & code reusability
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public BackendContext BackendContext
        {
            get { return Context as BackendContext; }
        }

        public ArtistRepository(DbContext context) : base(context)
        {
        }

        //Repository method called in the service layer by IoC
        //Returns a list of Artist, IEnumerable used to promote a larger array of options (List,Array, IList etc...) when used
        public IEnumerable<Artist> SearchArtist(string criteria)
        {
            return BackendContext.Artists.Where(a => a.Firstname.Contains(criteria) || a.Lastname.Contains(criteria));
        }
        
    }
}
using BackendDeveloperAssessment.IRepository;
using BackendDeveloperAssessment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperAssessment.Repository
{
    public class ArtistRepository : EFRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(BackendDeveloperAssessmentDbContext dbContext) : base(dbContext) { }

        public List<Artist> GetByCountry(string country)
        {
            return this.DbContext.Set<Artist>().Where(x => x.Country == country).ToList();
        }

    }
}

using BackendDeveloperAssessment.IRepository;
using BackendDeveloperAssessment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperAssessment.Repository
{
    public class AliasRepository : EFRepository<Aliases>, IAliasRepository
    {
        public AliasRepository(BackendDeveloperAssessmentDbContext dbContext) : base(dbContext) { }

        public List<Aliases> GetByArtistId(int artistId)
        {
            return this.DbContext.Set<Aliases>().Where(x => x.ArtistId == artistId).ToList();
        }
    }
}

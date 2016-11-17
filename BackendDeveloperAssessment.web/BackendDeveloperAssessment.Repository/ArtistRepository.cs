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

    }
}

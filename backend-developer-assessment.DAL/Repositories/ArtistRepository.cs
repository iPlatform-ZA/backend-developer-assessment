using backend_developer_assessment.DAL.Interfaces;
using backend_developer_assessment.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend_developer_assessment.Entities;
using System.Linq.Expressions;

namespace backend_developer_assessment.DAL.Repositories
{
    public class ArtistRepository: Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext _db)
            :base(_db)
        {
        }

        public int GetArtistCount()
        {
            var result = GetAll().Count();
            return result;
        }
    }
}

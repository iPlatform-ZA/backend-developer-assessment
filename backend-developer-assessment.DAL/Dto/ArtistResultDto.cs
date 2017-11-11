using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_developer_assessment.DAL.Dto
{
    public class ArtistResultDto
    {
        public List<AritstDto> results { get; set; }
        public int numberOfSearchResults { get; set; }
        public int page { get; set; }
        public int pageSize  { get; set; }
        public int numberOfPages { get; set; }
    }
}

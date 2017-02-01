using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ResultsModel
    {
        public List<ArtistModel> Artist { get; set; }
        public int numberOfSearchResults { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int numberOfPages { get; set; }

    }
}

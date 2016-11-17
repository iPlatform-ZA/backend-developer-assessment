using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperAssessment.Model
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string UniqueIdentifier { get; set; }
        public string Country { get; set; }

        public ICollection<Aliases> Aliases { get; set; }


    }
}

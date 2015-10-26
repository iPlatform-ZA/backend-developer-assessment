using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IplatformBEAssessment.Models.DTOs
{
    public class ArtistDTO
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public IEnumerable<EliasDTO> Eliases { get; set; }
    }
}
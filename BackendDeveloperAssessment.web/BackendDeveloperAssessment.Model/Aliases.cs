using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendDeveloperAssessment.Model
{
    public class Aliases
    {
        public int AliasesId { get; set; }
        public string AliasName { get; set; }

        public int ArtistId { get; set; }

        //[ForeignKey("ArtistId")]
        //public Artist Artist { get; set; }

        protected virtual Artist Artist { get; set; }

    }
}
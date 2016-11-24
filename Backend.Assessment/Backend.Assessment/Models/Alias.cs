namespace Backend.Assessment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alias")]
    public partial class Alias
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        public Guid ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}

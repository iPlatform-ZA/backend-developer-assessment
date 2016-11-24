namespace Backend.Assessment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Album")]
    public partial class Album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Album()
        {
            Album_Artist = new HashSet<Album_Artist>();
        }

        public Guid Id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? year { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Album_Artist> Album_Artist { get; set; }
    }
}

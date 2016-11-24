namespace Backend.Assessment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Country")]
    public partial class Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country()
        {
            Artists = new HashSet<Artist>();
        }

        [Key]
        [StringLength(2)]
        public string Iso { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        [StringLength(80)]
        public string PrintableName { get; set; }

        [StringLength(3)]
        public string Iso3 { get; set; }

        public int? Numcode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artist> Artists { get; set; }
    }
}

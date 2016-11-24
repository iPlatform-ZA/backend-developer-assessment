namespace Backend.Assessment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Artist")]
    public partial class Artist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artist()
        {
            Album_Artist = new HashSet<Album_Artist>();
            Aliases = new HashSet<Alias>();
        }

        public Guid Id { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(2)]
        public string CountryIso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Album_Artist> Album_Artist { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alias> Aliases { get; set; }

        public virtual Country Country { get; set; }
    }
}

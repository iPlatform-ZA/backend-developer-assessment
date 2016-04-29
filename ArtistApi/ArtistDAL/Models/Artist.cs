using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtistDAL.Models
{
    [Table("Artist")]
    public class Artist
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }
        
        public string Aliases { get; set; }
    }
}

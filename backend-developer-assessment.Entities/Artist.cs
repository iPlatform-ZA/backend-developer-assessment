using System.ComponentModel.DataAnnotations;

namespace backend_developer_assessment.Entities
{
    public class Artist
    {
        [Key]
        public string Id { get; set; }
        [Required, StringLength(1024)]
        public string ArtistName { get; set; }
        [StringLength(5)]
        public string CountryCode { get; set; }
        [StringLength(1024)]
        public string ArtistAliases { get; set; }

    }
}

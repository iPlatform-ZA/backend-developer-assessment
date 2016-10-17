using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackendApi.Models
{
    public class Artist
    {
        [JsonProperty("name")]
        [MaxLength(150)]
        [MinLength(2)]
        [Required]
        public string   Name { get; set; }
        [MaxLength(150)]
        [MinLength(2)]
        [Required]
        [JsonProperty("country")]
        public string  Country   { get; set; }
        [MaxLength(500)]
        [JsonIgnore]
        public string  Aliases { get; set; }
        [JsonProperty("alias")]
        [NotMapped]
        public string[] Alias { get; set; }
        [JsonProperty("id")]
        [Key]
        public Guid Id { get; set; }
<<<<<<< HEAD
        [NotMapped]
        [JsonProperty("albums")]
        public string Albums { get; internal set; }
=======
>>>>>>> refs/remotes/origin/master
    }
}
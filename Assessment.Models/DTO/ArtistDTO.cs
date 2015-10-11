using System;
using System.Collections.Generic;

namespace Assessment.Models.DTO
{
    public class ArtistDTO
    {
        public string Name {get; set;}
        public string Country {get; set;}
        public List<string> Alias {get; set;}
        public List<AlbumDTO> Albums { get; set; }
    }
}

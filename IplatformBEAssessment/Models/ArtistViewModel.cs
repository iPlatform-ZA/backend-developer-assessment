using Domain;
using IplatformBEAssessment.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IplatformBEAssessment.Models
{
    public class ArtistViewModel
    {
        public ArtistViewModel()
        {
            Artists = new List<ArtistDTO>();
        }
        public IEnumerable<ArtistDTO> Artists { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }
    }
}
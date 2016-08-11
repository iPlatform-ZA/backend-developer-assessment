using System;
using System.Runtime.Serialization;

namespace WebApi.Models
{
    public class CompositeArtist
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string[] Alias { get; set; }
        public string ArtistAlbums { get; set; }
    }
}
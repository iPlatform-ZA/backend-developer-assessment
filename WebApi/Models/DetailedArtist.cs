using System;
using System.Runtime.Serialization;

namespace WebApi.Models
{
    public class DetailedArtist
    {
        [IgnoreDataMember]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string[] Alias { get; set; }
        public string LinkToAlbums { get; set; }
    }
}
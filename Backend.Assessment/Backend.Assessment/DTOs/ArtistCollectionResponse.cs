using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace Backend.Assessment.DTOs
{
    [DataContract]
    public class ArtistCollectionResponse
    {
        [DataMember(Name ="name")]
        public string Name { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "alias")]
        public List<string> Alias { get; set; }
    }
}
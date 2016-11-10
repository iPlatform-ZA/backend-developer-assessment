using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Backend_Assessment.Models
{
    public class ArtistAlias
    {
        public Guid Identifier { get; set; }    
        public string Alias { get; set; }
    }
}
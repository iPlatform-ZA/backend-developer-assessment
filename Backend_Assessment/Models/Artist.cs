using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Backend_Assessment.Models
{
    public class Artist
    {
        [Newtonsoft.Json.JsonIgnore]   
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<string> Aliases { get; set; }
    }
}
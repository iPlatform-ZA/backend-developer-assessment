using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperAssessment.Model.Release
{
    public class releases
    {
        public string id { get; set; }
        public string score { get; set; }
        public int count { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        [JsonProperty(PropertyName = "text-representation")]
        public textrepresentation textrepresentation { get; set; }
    }
}

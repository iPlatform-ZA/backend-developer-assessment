using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDA.Models
{
    public class ReleaseResponseModel
    {
        public ReleaseResponseModel()
        {
            Releases = new List<ReleaseModel>();
        }
        [JsonProperty("releases")]
        public List<ReleaseModel> Releases { get; set; }
    }
}
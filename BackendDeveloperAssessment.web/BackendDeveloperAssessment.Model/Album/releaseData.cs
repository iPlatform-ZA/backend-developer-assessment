using BackendDeveloperAssessment.Model.Album;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperAssessment.Model.Release
{
    public class releaseAlbumData
    {
        public string created { get; set; }
        public int count { get; set; }
        public int offset { get; set; }
        public List<release> releases { get; set; }
    }
}

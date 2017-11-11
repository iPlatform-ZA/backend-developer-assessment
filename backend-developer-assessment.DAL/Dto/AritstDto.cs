using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_developer_assessment.DAL.Dto
{
    public class AritstDto
    {
        public string name { get; set; }
        public string country { get; set; }
        public List<string> alias { get; set; }
    }
}

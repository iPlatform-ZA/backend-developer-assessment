using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassLib.Abstract;

namespace ClassLib.Models
{
    public class ReleaseResult:ReleaseResultBase
    {
        public ReleaseResult(XElement entity) : base(entity)
        {

        }
    }
}

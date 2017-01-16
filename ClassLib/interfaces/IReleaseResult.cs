using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.interfaces
{
    public interface IReleaseResult
    {
        string ReleaseId { get; set; }
        string Title { get; set; }
        string Status { get; set; }
        string Label { get; set; }
        string NumberOfTracks { get; set; }

    }
}

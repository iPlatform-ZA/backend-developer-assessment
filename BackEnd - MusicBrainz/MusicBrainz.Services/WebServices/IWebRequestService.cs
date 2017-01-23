using MusicBrainz.Platform.Domain.MusicBrainz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicBrainz.Services.WebServices
{
    public interface IWebRequestService
    {
        XElement Get(string artistId);
        Release GetReleases(string artistId);
    }
}

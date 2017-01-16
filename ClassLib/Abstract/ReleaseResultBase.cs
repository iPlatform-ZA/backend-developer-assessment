using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using ClassLib.interfaces;

namespace ClassLib.Abstract
{
    public abstract class ReleaseResultBase:IReleaseResult
    {
        public ReleaseResultBase(XElement release)
        {
            _releaseId = release.Attributes().FirstOrDefault(x => x.Name.LocalName == "id").Value;
            _title = release.Elements().FirstOrDefault(x => x.Name.LocalName == "title").Value;
            if (release.Elements().Any(x => x.Name.LocalName == "status"))
            {
                _status = release.Elements().FirstOrDefault(x => x.Name.LocalName == "status").Value;
            }
            
            if (release.Elements()
                .Any(x => x.Name.LocalName == "label-info-list"))
            {
                _label =
                release.Elements()
                    .FirstOrDefault(x => x.Name.LocalName == "label-info-list")
                    .Elements()
                    .FirstOrDefault(x => x.Name.LocalName == "label-info")
                    .Elements()
                    .FirstOrDefault(x => x.Name.LocalName == "label").Elements().FirstOrDefault(x => x.Name.LocalName == "name").Value;
            }
            
                    
            _numberOfTracks =
                release.Elements()
                    .FirstOrDefault(x => x.Name.LocalName == "medium-list")
                    .Elements()
                    .FirstOrDefault(x => x.Name.LocalName == "track-count")
                    .Value;
        }

        private string _releaseId;
        private string _title;
        private string _status;
        private string _label;
        private string _numberOfTracks;

        public string ReleaseId
        {
            get { return _releaseId; }
            set { _releaseId = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        public string NumberOfTracks
        {
            get { return _numberOfTracks; }
            set { _numberOfTracks = value; }
        }
    }
}

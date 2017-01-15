using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Data;
using ClassLib.interfaces;

namespace ClassLib.Abstract
{
    public abstract class ArtistsBase:IArtist
    {
        protected ArtistsBase(Artist artists)
        {
            _uniqueId = artists.UniqueId;
            _artistsName = artists.ArtistsName;
            _country = artists.Country;
            _aliases = artists.Aliases;
        }

        private Guid _uniqueId;
        private string _artistsName;
        private string _country;
        private string _aliases;

        public Guid UniqueId
        {
            get { return _uniqueId; }
            set { _uniqueId = value; }
        }

        public string ArtistsName
        {
            get { return _artistsName; }
            set { _artistsName = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string Aliases
        {
            get { return _aliases; }
            set { _aliases = value; }
        }
    }
}

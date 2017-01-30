using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.interfaces;

namespace ClassLib.Abstract
{
    public abstract class CollaboratingArtistBase:ICollaboratingArtist
    {
        public CollaboratingArtistBase(string id, string name)
        {
            _id = id;
            _name = name;
        }

        private string _id;
        private string _name;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}

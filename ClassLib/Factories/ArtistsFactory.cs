using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using ClassLib.Abstract;
using ClassLib.interfaces;
using Microsoft.Practices.Unity;

namespace ClassLib.Factories
{
    public class ArtistsFactory<T,TY>:FactoryBase<T,TY> where T:class where TY:class
    {
        public TY GetObject(IDBEntity entity)
        {
            return (TY)Container.Resolve(typeof (TY), (typeof (TY)).Name, new ParameterOverride("artists", entity));
        }

        public TY GetObject(XElement entity)
        {
            return (TY)Container.Resolve(typeof(TY), (typeof(TY)).Name, new ParameterOverride("entity", entity));
        }
    }
}

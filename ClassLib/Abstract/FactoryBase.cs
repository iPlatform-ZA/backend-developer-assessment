using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.interfaces;
using ClassLib.Models;
using Microsoft.Practices.Unity;

namespace ClassLib.Abstract
{
    public abstract class FactoryBase<T,TY>:IFactory<T,TY> where T:class where TY:class
    {
        private IUnityContainer _container;

        public IUnityContainer Container
        {
            get { return _container; }
            set { _container = value; }
        }

        public FactoryBase()
        {
            _container = new UnityContainer();

            _container.RegisterType(typeof(T),typeof(TY), typeof (TY).Name);
        } 
    }
}

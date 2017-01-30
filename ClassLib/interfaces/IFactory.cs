using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace ClassLib.interfaces
{
    public interface IFactory<T,TY>
    {
        IUnityContainer Container { get; set; }
    }
}

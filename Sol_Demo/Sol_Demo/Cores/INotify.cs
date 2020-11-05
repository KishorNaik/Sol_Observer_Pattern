using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Cores
{
    public interface INotify
    {
        event EventHandler<Action<List<IObserver>>> OnNotify;
    }
}
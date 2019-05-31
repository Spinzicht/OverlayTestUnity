using Ludio.Data;
using Ludio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ludio.Commands
{
    public interface IListener<T>
    {
        void Updated(T obj);
    }

    public interface ISender<T> : IComposite<IListener<T>> { }
}

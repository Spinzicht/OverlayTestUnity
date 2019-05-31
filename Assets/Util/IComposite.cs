using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ludio.Util
{
    public interface IComposite<T>
    {
        List<T> Children { get; }

        void Add(T o);
        void Remove(T o);
    }
}

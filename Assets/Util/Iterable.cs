using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ludio.Util
{
    public interface Iterable
    {
        Iterator CreateIterator();
    }

    public interface Iterable<T> : IComposite<T>, Iterable
    {
        ListIterator<T> IteratorInstance();
    }
}

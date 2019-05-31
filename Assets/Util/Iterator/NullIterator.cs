using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ludio.Util
{
    public class NullIterator : Iterator
    {
        private object obj;
        public NullIterator(object o) { obj = o; }
        public override object Current { get { return obj; } }
    }
}

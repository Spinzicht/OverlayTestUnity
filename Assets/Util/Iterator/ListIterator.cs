using Ludio.Data.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ludio.Util
{
    public class ListIterator<T> : Iterator<T>
    {
        private List<T> Children { get; set; }
        public ListIterator(List<T> children) { Children = children; }

        public override bool IsLast() { return Index >= Children.Count - 1; }
        public override bool IsDone() { return Index >= Children.Count; }

        public override object Current { get { return Target; } }
        public override T Target { get { return Children.ElementAt(Index); } }

        public override int Length { get { return Children.Count; } }
    }
}

using Ludio.Util;

namespace Ludio.Data
{
    public abstract class Activity : DBObject, Iterable
    {
        public virtual Iterator CreateIterator() { return new NullIterator(this); }
    }
}

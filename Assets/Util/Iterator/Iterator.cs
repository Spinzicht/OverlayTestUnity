
namespace Ludio.Util
{
    public abstract class Iterator
    {
        public int Index { get; protected set; }

        public Iterator() { Index = 0; }

        public virtual void First() { Index = 0; }
        public virtual void Next() { Index++; }
        public virtual bool IsDone() { return true; }
        public virtual bool IsLast() { return true; }

        public abstract object Current { get; }
        public virtual int Length { get { return 0; } }
    }

    public abstract class Iterator<T>  : Iterator
    {
        public abstract T Target { get; }
    }
}

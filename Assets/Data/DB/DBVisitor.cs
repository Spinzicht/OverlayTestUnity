using Ludio.Data.Tasks;

namespace Ludio.Data.DB
{
    public abstract class DBVisitor
    {
        private Database Database { get; set; }

        public abstract void Sync(DBObject o);
        public abstract void Sync(Activity a);
        public abstract void Sync(Training t);
        public abstract void Sync(Instruction i);
    }
}
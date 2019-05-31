using Ludio.Data.Tasks;

namespace Ludio.Data.DB
{
    public class DBGetter : DBVisitor
    {
        public override void Sync(Activity a) { }
        public override void Sync(Training t) { }
        public override void Sync(Instruction i) { }

        public override void Sync(DBObject o) { }
    }
}
using Ludio.Data.DB;

namespace Ludio.Data.Tasks
{
    public class Instruction : Task
    {
        public virtual string ImageURL { get; set; }

        public override bool IsDone { get; set; }

        public override Task Current { get { return this; } }

        public Instruction() { }

        public Instruction(string text, Task parent = null) : base(text, parent) {  }

        public override void Sync(DBVisitor db) { db.Sync(this); }

        
    }
}
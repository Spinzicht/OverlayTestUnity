using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ludio.Data
{
    public abstract class DBObject {
        public string SID { get; set; }

        public abstract void Sync(DB.DBVisitor db);
    }
}

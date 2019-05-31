using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ludio.Data.DB
{
    public class Firebase : Database
    {
        public override bool Create<T>(string path, T obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete<T>(string path, string prop, T obj)
        {
            throw new NotImplementedException();
        }

        public override object GetCollection<T>(string path) { return null; }
        public override IEnumerable<T> GetAll<T>(string path, Expression<Func<T, bool>> ex) { return null; }
        public override T GetObject<T>(string path, Expression<Func<T, bool>> ex) { return default(T); }

        public override bool Update<T>(string path, T obj)
        {
            throw new NotImplementedException();
        }
    }
}

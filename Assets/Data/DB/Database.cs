using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ludio.Data.DB
{
    public abstract class Database
    {
        public abstract bool Create<T>(string path, T obj);
        public abstract bool Update<T>(string path, T obj);
        public abstract object GetCollection<T>(string path);
        public abstract IEnumerable<T> GetAll<T>(string path, Expression<Func<T, bool>> ex = null);
        public abstract T GetObject<T>(string path, Expression<Func<T, bool>> ex);
        public abstract bool Delete<T>(string path, string prop, T obj);
    }
}
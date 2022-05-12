using Evry.Evaluation.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evry.Evaluation.Data
{
    /// <summary>
    /// Data session for testing data access without database.
    /// </summary>
    public class TestDataSession : IDataSession
    {
        private Dictionary<Type, object> _data;

        public TestDataSession()
        {
            _data = new Dictionary<Type, object>();
        }

        public void Dispose() { }

        public void SetModified<T>(T entity) where T : class
        {
        }

        // There's nothing to "save", per se so it's just a NOOP
        public int SaveChanges() { return 1; }

        public int SqlCommand(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void SaveSet<T>(IEnumerable<T> set) where T : class
        {
            var dbSet = new FakeDbSet<T>(set);
            var type = typeof(T);
            if (_data.ContainsKey(type))
                _data[type] = dbSet;
            else
                _data.Add(type, dbSet);
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return _data[typeof(T)] as FakeDbSet<T>;
        }
    }
}

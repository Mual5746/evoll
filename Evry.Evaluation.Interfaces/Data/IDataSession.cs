using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evry.Evaluation.Interfaces.Data
{
    public interface IDataSession : IDisposable
    {
        IDbSet<T> Set<T>() where T : class;

        void SaveSet<T>(IEnumerable<T> set) where T : class;

        int SaveChanges();

        void SetModified<T>(T entity) where T : class;

        int SqlCommand(string sql, params object[] parameters);
    }
}

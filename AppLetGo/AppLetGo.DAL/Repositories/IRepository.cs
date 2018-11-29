using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppLetGo.DAL
{
    public interface IRepository<T> : IDisposable where T : class, new()
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
        T Get(Expression<Func<T, bool>> predicate);
        T Get(int id);
        void Save();

    }
}

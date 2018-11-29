using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<T> GetAll();
        T Get(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        void Save();

    }
}

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
        Task<bool> InsertAsync(T entity);
        Task<bool> Update(T entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetFillterAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> GetByIdAsync(int id);
        
        void Save();

    }
}

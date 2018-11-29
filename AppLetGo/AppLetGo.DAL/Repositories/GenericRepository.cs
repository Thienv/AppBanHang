using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppLetGo.DAL
{
    public class GenericRepository<T> : IRepository<T> where T : class, new()
    {
        private SQLiteConnection db;

        public GenericRepository(SQLiteConnection _db)
        {
            this.db = _db;
        }
        public void Delete(T entity)
        {
            db.Delete(entity);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            return db.Find<T>(id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return db.Find<T>(predicate);
        }

        public List<T> GetAll<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = db.Table<T>();
            if (predicate != null)
                query = query.Where(predicate);
            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);
            return query.ToList();
        }

        public void Insert(T entity)
        {
            db.Insert(entity);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            db.Update(entity);
        }
    }
}

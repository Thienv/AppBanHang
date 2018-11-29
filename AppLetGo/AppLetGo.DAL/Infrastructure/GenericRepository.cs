using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppLetGo.DAL
{
    public class GenericRepository<T> : IRepository<T> where T : class, new()
    {
        private SQLiteConnection db;

        public GenericRepository(IContext _db)
        {
            _db = new DataContext();
            this.db = _db.GetConnection();
            _db.InitializeDatabase();
            
            
        }
        public void Delete(T entity)
        {
            db.Delete(entity);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            return db.Find<T>(id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return db.Find<T>(predicate);
        }

        public ObservableCollection<T> GetAll()
        {
            var query = db.Table<T>();            
            var result = new ObservableCollection<T>(query);
            return result;
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

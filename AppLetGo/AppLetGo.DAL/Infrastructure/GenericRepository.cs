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
        private SQLiteAsyncConnection db;

        public GenericRepository(IContext _db)
        {
            _db = new DataContext();
            this.db = _db.GetConnection();
            _db.InitializeDatabaseAsync();
            
            
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await db.FindAsync<T>(id);
                await db.DeleteAsync(entity);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await db.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetFillterAsync(Expression<Func<T, bool>> predicate = null)
        {
            var query = db.Table<T>();
            if (predicate != null)
                query = query.Where(predicate);

            //if (orderBy != null)
            //    query = query.OrderBy<TValue>(orderBy);
            return await query.ToListAsync();
        }

        

        public async Task<bool> InsertAsync(T entity)
        {
            try
            {
                await db.InsertAsync(entity);
                return true;
            }
            catch
            {
                return false;
            }
             
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                await db.UpdateAsync(entity);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var query =  db.Table<T>();
            
            return await query.ToListAsync();
        }

        

       
    }
}

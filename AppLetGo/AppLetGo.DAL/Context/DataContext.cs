using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppLetGo.DAL
{
    public class DataContext : IContext
    {
        private SQLiteAsyncConnection _context;
        private string _dbPath;

        public DataContext()
        {
            this._dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DBStore1");
            this._context = new SQLiteAsyncConnection(this._dbPath);
        }
        public SQLiteAsyncConnection GetConnection()
        {
            return this._context;
        }

        public async Task InitializeDatabaseAsync()
        {
            await this._context.CreateTablesAsync<Loaihoa, Hoa>();
            
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            // this._dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DBStore");

            //if (IntPtr.Size == 8) // or for .NET4 use Environment.Is64BitProcess
            //{
            //    this._dbPath = Path.Combine(this._dbPath, "64");
            //}
            //else
            //{
            //    this._dbPath = Path.Combine(this._dbPath, "32");
            //}

            //this._dbPath = Path.Combine(this._dbPath, "System.Data.SQLite.DLL");
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

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
        private SQLiteConnection _context;
        private string _dbPath;

        public DataContext()
        {
            this._dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DBStore");
            this._context = new SQLiteConnection(this._dbPath);
        }
        public SQLiteConnection GetConnection()
        {
            return this._context;
        }

        public void InitializeDatabase()
        {
            this._context.CreateTable<Hoa>();
        }
    }
}

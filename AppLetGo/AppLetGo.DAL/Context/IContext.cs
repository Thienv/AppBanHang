using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLetGo.DAL
{
    public interface IContext
    {
        void InitializeDatabase();
        SQLiteConnection GetConnection();
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLetGo.DAL.Models
{
    public class Loaihoa
    {
        [PrimaryKey, AutoIncrement]
        public int Maloai { get; set; }
        public string Tenloai { get; set; }
    }
}

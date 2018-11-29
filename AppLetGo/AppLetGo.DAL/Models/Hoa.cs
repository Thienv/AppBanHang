using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLetGo.DAL
{
    public class Hoa
    {
        [PrimaryKey, AutoIncrement]
        public int Mahoa { get; set; }
        public int Maloai { get; set; }
        public string Tenhoa { get; set; }
        public string Hinh { get; set; }
        public string Mota { get; set; }
        public double Gia { get; set; }
    }
}

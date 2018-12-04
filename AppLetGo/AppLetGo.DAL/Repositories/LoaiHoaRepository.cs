using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLetGo.DAL
{
    public interface ILoaiHoaRepository : IRepository<Loaihoa>
    {

    }
    public class LoaiHoaRepository : GenericRepository<Loaihoa> , ILoaiHoaRepository
    {
        public LoaiHoaRepository(IContext context) : base(context)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLetGo.DAL
{
    public interface IHoaRepository : IRepository<Hoa>
    {

    }
    public class HoaRepository : GenericRepository<Hoa> , IHoaRepository 
    {
        public HoaRepository(IContext context) : base(context)
        {

        }
    }
}

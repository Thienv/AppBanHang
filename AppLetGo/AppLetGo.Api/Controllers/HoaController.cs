using AppLetGo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppLetGo.Api.Controllers
{
    public class HoaController : ApiController
    {
        
        IHoaService _hoaService;
        public HoaController()
        {
            _hoaService = new HoaService();
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IEnumerable<HoaDto>> GetAllProductsAsync()
        {
            var result =await _hoaService.GetHoasAsync();
            return result.Select(x => new HoaDto
            {

                Gia = x.Gia,
                Hinh = x.Hinh,
                Mahoa = x.Mahoa,
                Maloai = x.Maloai,
                Mota = x.Mota,
                Tenhoa = x.Tenhoa
            });
        }
    }
}

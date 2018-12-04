using AppLetGo.Business;
using AppLetGo.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AppLetGo.Api.Controllers
{
    public class HoaController : ApiController
    {
        
        private IHoaService _hoaService;
        

        public HoaController()
        {
            _hoaService = new HoaService();
        }
        //[Route("api/hoas/getall/")]
        //[HttpGet]
        //[ResponseType(typeof(Hoas))]
        //public async System.Threading.Tasks.Task<IHttpActionResult> GetAllHoaAsync()
        //{

        //   var hoas = await this._hoaService.GetHoasAsync().Select(x => new Hoas
        //            {
        //                TenHoa = x.Tenhoa,
        //                MaHoa = x.Mahoa,
        //                Gia =x.Gia,
        //                Hinh = x.Hinh, 
        //                MaLoai = x.Maloai,
        //                MoTa = x.Mota
        //            }).ToList();
        //    if (hoas == null)
        //    {
        //        return NotFound(); // Returns a NotFoundResult
        //    }
        //    return Ok(hoas);

        //}
    }
}

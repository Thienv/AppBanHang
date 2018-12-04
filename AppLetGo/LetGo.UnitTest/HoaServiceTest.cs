using AppLetGo.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using AppLetGo.DAL;
using System.Collections.ObjectModel;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace LetGo.UnitTest
{
    [TestClass]
    public class HoaServiceTest
    {
        private IHoaRepository _HoaRepository;
        private IHoaService _hoaService;
        private ObservableCollection<Hoa> _listHoa;

        public HoaServiceTest()
        {
            _hoaService = new HoaService();
        }
        //public void Inintalize()
        //{
        //    this._mockHoaRepository = new Mock<IHoaRepository>();
        //    _hoaService = new HoaService(_mockHoaRepository.Object);
        //    this._listHoa = new ObservableCollection<Hoa>()
        //    {
        //        new Hoa() {Tenhoa = "Hoa Hong", Gia = 1000, Hinh = "", Mahoa = 1, Maloai = 1, Mota = "Khong co gi" },
        //        new Hoa() {Tenhoa = "Hoa Cuc", Gia = 10001, Hinh = "", Mahoa = 2, Maloai = 1, Mota = "Hoa Cuc" },
        //        new Hoa() {Tenhoa = "Hoa Tuoi", Gia = 10004, Hinh = "", Mahoa = 3, Maloai = 2, Mota = "Hoa Tuoi" },
        //    };
        //}
        [TestMethod]
        public async Task Hoa_Service_GetAllAsync()
        {
            bool flat = true;
            //call action
            var result = await _hoaService.GetHoasAsync() ;
            if(result.Count() >0)
            {
                flat = false;
            }
            //compare
            Assert.IsFalse(flat, "1 should not be prime");
            
        }
        [TestMethod]
        public async Task Hoa_Service_GetHoaByIdAsync()
        {
            bool flat = true;
            //call action
            var result = await _hoaService.GetHoasByIdAsync(1);
            
            //compare
            Assert.IsFalse(flat, "1 should not be prime");

        }
        [TestMethod]
        public async Task InsetHoaAsync()
        {
            Hoa hoa = new Hoa();
            
            hoa.Tenhoa = "Hoa huong duong mau Xanh";
            hoa.Mota = "hoa mau vang";
            hoa.Maloai = 2;
            hoa.Mahoa = 2;
            hoa.Hinh = "";
            hoa.Gia = 60000;
            ;

            //_mockHoaRepository.Setup(m => m.Insert(hoa));

             await Task.Run(()=>_hoaService.Insert(hoa));
             
            //Assert.IsNotNull(result);
        }
        [TestMethod]
        public async Task DeleteHoaId()
        {
            await Task.Run(() => _hoaService.Delete(1));
        }

        public async Task UpdateHoaId()
        {
            
            await Task.Run(() => _hoaService.Delete(1));
        }

        [TestMethod]
        public async Task GetHoaByLoai()
        {
            var result = await _hoaService.GetHoasByLoai(2);
        }
    }
    
}

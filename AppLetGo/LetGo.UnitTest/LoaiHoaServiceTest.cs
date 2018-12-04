using AppLetGo.Business;
using AppLetGo.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetGo.UnitTest
{
    [TestClass]
    public class LoaiHoaServiceTest
    {
        
        private ILoaiHoaService _loaihoaService;
        

        public LoaiHoaServiceTest()
        {
            _loaihoaService = new LoaiHoaService();
        }

        [TestMethod]
        public async Task InsetLoaiHoaAsync()
        {
            var loaihoa = new Loaihoa();
            loaihoa.Maloai = 1;
            loaihoa.Tenloai = "Hoa Tết";          
            

            //_mockHoaRepository.Setup(m => m.Insert(hoa));

            bool flat =  await  _loaihoaService.Insert(loaihoa);
            Assert.IsFalse(!flat, "Insert Sussecfull");
            //Assert.IsNotNull(result);
        }
        [TestMethod]
        public async Task getLoaiHoas()
        {
            var result = await _loaihoaService.GetLoaiHoas();
            Assert.IsNotNull(result);
        }
    }
}

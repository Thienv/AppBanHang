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
        public void Hoa_Service_GetAll()
        {
            bool flat = false;
            //call action
            var result = _hoaService.GetHoas() ;
            if(result.Count() >0)
            {
                flat = true;
            }
            //compare
            Assert.IsFalse(flat, "1 should not be prime");
            
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            Hoa hoa = new Hoa();
            
            hoa.Tenhoa = "Hoa Hong";
            hoa.Mota = "Cay Hoa Hong";
            hoa.Maloai = 1;
            hoa.Mahoa = 1;
            hoa.Hinh = "";
            hoa.Gia = 10000;
            ;

            //_mockHoaRepository.Setup(m => m.Insert(hoa));

            _hoaService.Insert(hoa);
             
            //Assert.IsNotNull(result);
            //Assert.AreEqual(1, result.ID);


        }
    }
    
}

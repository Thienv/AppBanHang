using AppLetGo.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppLetGo
{
    public class ThemHoaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string PropertyName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public ICommand AddHoa { get; set; }
        public ILoaiHoaService loaiHoaService;
        public IHoaService hoaService;
        private List<LoaiHoaDto> loaihoas;
        private List<HoaDto> hoas;
        private LoaiHoaDto loahoa;
        private HoaDto hoa;

        public ThemHoaViewModel()
        {
            loaiHoaService = new LoaiHoaService();
            hoaService = new HoaService();

            Task loaiHoas = Task.Run(async () => await loaiHoaService.GetLoaiHoas());
            Task hoas = Task.Run(async () => await hoaService.GetHoasAsync());
            loahoa = new LoaiHoaDto();
            hoa = new HoaDto();
            
        }

        public List<LoaiHoaDto> loaiHoas
        {
            get { return loaiHoas; }
            set
            {
                loaiHoas = value;
                RaisePropertyChanged("LoaiHoas");
            }
        }
        public LoaiHoaDto LoaHoaChon
        {
            get { return loahoa; }
            set { loahoa = value;
                hoa.Mahoa = loahoa.Maloai;
                Task.Run(async () => await LayHoaTheoLoai()); 
                RaisePropertyChanged("LoaiHoaChon");
            }
        }

        public async Task LayHoaTheoLoai()
        {
            if (LoaHoaChon != null && loahoa.Maloai > 0)
                DSHoa = await hoaService.GetHoasByLoai(LoaHoaChon.Maloai);
            else
                DSHoa = await hoaService.GetHoasAsync();
        }

        public HoaDto Hoamoi
        {
            get { return hoa; }
            set
            {
                hoa = value;
                RaisePropertyChanged("LoaihoaChon");
            }

        }
        public List<HoaDto> DSHoa
        {
            get { return hoas; }
            set
            {
                hoas = value;
                RaisePropertyChanged("DSHoa");
            }

        }





    }
}

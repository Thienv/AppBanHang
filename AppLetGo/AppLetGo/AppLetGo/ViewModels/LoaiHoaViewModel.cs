using AppLetGo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppLetGo.ViewModels
{
    public class LoaiHoaViewModel: BaseViewModel
    {
        private Hoa hoa;
        private LoaiHoa loaihoa;
        private ObservableCollection<LoaiHoa> _loaiHoaList;
        private ObservableCollection<Hoa> _hoaList;
        private ObservableCollection<Hoa> _hoaTheoLoai;
        private ObservableCollection<Hoa> temp = new ObservableCollection<Hoa>();
        
        //public ICommand AddLoaiHoa { get; private set; }

        public LoaiHoaViewModel()
        {
            loaihoa = new LoaiHoa();
            hoa = new Hoa();
           // AddHoa = new Command(Insert(Hoa h));
            // du lieu gia
            LoaiHoaList = new ObservableCollection<LoaiHoa>();
            HoaList = new ObservableCollection<Hoa>();
            HoaTheoLoai = new ObservableCollection<Hoa>();



            LoaiHoa a = new LoaiHoa() { Maloai = 1, Tenloai = "hoa gia" };
            LoaiHoa b = new LoaiHoa() { Maloai = 2, Tenloai = "hoa cuoi" };
            LoaiHoa c = new LoaiHoa() { Maloai = 3, Tenloai = "hoa hong" };
            LoaiHoa d = new LoaiHoa() { Maloai = 4, Tenloai = "hoa lan" };
            LoaiHoa e = new LoaiHoa() { Maloai = 5, Tenloai = "hoa cuc" };
            LoaiHoaList.Add(a);
            LoaiHoaList.Add(b);
            LoaiHoaList.Add(c);
            LoaiHoaList.Add(d);
            LoaiHoaList.Add(e);


            Hoa s1 = new Hoa() { Mahoa = 1, Maloai = 1, Tenhoa = "gia1" };
            Hoa s2 = new Hoa() { Mahoa = 2, Maloai = 1, Tenhoa = "gia2" };
            Hoa s3 = new Hoa() { Mahoa = 3, Maloai = 2, Tenhoa = "cuoi1" };
            Hoa s4 = new Hoa() { Mahoa = 4, Maloai = 2, Tenhoa = "cuoi2" };
            Hoa s5 = new Hoa() { Mahoa = 5, Maloai = 3, Tenhoa = "hong1" };
            Hoa s6 = new Hoa() { Mahoa = 6, Maloai = 3, Tenhoa = "hong2" };
            Hoa s7 = new Hoa() { Mahoa = 7, Maloai = 4, Tenhoa = "lan1" };
            Hoa s8 = new Hoa() { Mahoa = 8, Maloai = 4, Tenhoa = "lan2" };
            Hoa s9 = new Hoa() { Mahoa = 9, Maloai = 5, Tenhoa = "cuc1" };
            Hoa s10 = new Hoa() { Mahoa = 10, Maloai = 5, Tenhoa = "cuc2" };

            HoaList.Add(s1);
            HoaList.Add(s2);
            HoaList.Add(s3);
            HoaList.Add(s4);
            HoaList.Add(s5);
            HoaList.Add(s6);
            HoaList.Add(s7);
            HoaList.Add(s8);
            HoaList.Add(s9);
            HoaList.Add(s10);

            // het du lieu gia


        }
        public void Insert(Hoa h)
        {
            
            HoaList.Add(h);
            HoaTheoLoai = HoaList;
        }

        private void Load()
        {
            //temp = new ObservableCollection<Hoa>();
            //temp = HoaList;
            HoaTheoLoai = HoaList;
        }
        public ObservableCollection<Hoa> HoaTheoLoai
        {
            get { return _hoaTheoLoai; }
            set { _hoaTheoLoai = value; OnPropertyChanged(); }
        }
        public ObservableCollection<LoaiHoa> LoaiHoaList
        {
            get { return _loaiHoaList; }
            set
            {
                _loaiHoaList = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Hoa> HoaList
        {
            get { return _hoaList; }
            set { _hoaList = value; OnPropertyChanged(); }
        }
        public LoaiHoa Loaihoa
        {
            get { return loaihoa; }
            set
            {
                loaihoa = value;
                OnPropertyChanged();
            }
        }
        public string Tenloai
        {
            get { return loaihoa.Tenloai; }
            set
            {
                loaihoa.Tenloai = value;
                OnPropertyChanged();
            }
        }
        public LoaiHoa LoaihoaChon
        {
            get { return loaihoa; }
            set
            {
                loaihoa = value;
                OnPropertyChanged();
                hoa.Maloai = loaihoa.Maloai;
                LayHoaTheoLoai();
            }

        }
        private void LayHoaTheoLoai()
        {

            HoaTheoLoai = new ObservableCollection<Hoa>();
            if (LoaihoaChon != null && LoaihoaChon.Maloai > 0)
                for (int j = 0; j < 10; j++)
                {
                    if (HoaList[j].Maloai == LoaihoaChon.Maloai)
                    {
                        HoaTheoLoai.Add(HoaList[j]);
                    }
                }
            else
                HoaTheoLoai = HoaList;
        }        
        public int ID
        {
            get { return loaihoa.Maloai; }
            set
            {
                loaihoa.Maloai = value;
                OnPropertyChanged();
            }
        }
        //private bool CanExe()
        //{
        //    if (Loaihoa == null || Loaihoa.Maloai == 0)
        //        return false;
        //    else
        //        return true;
        //}
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using AppLetGo.DAL;

namespace AppLetGo.ViewModels
{
    class HoaViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ILoaiHoaRepository loaihoaRepository;

        private IHoaRepository hoaRepository;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        private Hoa hoa;
        public Hoa Hoachon
        {
            get { return hoa; }
            set
            {
                hoa = value;
                RaisePropertyChanged("Hoachon");
            }
        }
        public int Mahoa
        {
            get { return hoa.Mahoa; }
            set
            {
                hoa.Mahoa = Mahoa;
                RaisePropertyChanged("Mahoa");
            }
        }
        public int Maloai
        {
            get { return hoa.Maloai; }
            set
            {
                hoa.Maloai = value;
                RaisePropertyChanged("Maloai");
            }
        }
        public string Tenhoa
        {
            get { return hoa.Tenhoa; }
            set
            {
                hoa.Tenhoa = value;
                RaisePropertyChanged("Tenhoa");
            }
        }
        public string Hinh
        {
            get { return hoa.Hinh; }
            set
            {
                hoa.Hinh = value;
                RaisePropertyChanged("Hinh");
            }
        }
        public string Mota
        {
            get { return hoa.Mota; }
            set
            {
                hoa.Mota = value;
                RaisePropertyChanged("Mota");
            }
        }
        public double Gia
        {
            get { return hoa.Gia; }
            set
            {
                hoa.Gia = value;
                RaisePropertyChanged("Gia");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using AppLetGo.Business;
using AppLetGo.DAL;

namespace AppLetGo
{
    public class HoaViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IHoaService HoaService;

        private ILoaiHoaService loaihoaService;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        private HoaDto hoaDto;
        public HoaDto Hoachon
        {
            get { return hoaDto; }
            set
            {
                hoaDto = value;
                RaisePropertyChanged("Hoachon");
            }
        }
        public int Mahoa
        {
            get { return hoaDto.Mahoa; }
            set
            {
                hoaDto.Mahoa = Mahoa;
                RaisePropertyChanged("Mahoa");
            }
        }
        public int Maloai
        {
            get { return hoaDto.Maloai; }
            set
            {
                hoaDto.Maloai = value;
                RaisePropertyChanged("Maloai");
            }
        }
        public string Tenhoa
        {
            get { return hoaDto.Tenhoa; }
            set
            {
                hoaDto.Tenhoa = value;
                RaisePropertyChanged("Tenhoa");
            }
        }
        public string Hinh
        {
            get { return hoaDto.Hinh; }
            set
            {
                hoaDto.Hinh = value;
                RaisePropertyChanged("Hinh");
            }
        }
        public string Mota
        {
            get { return hoaDto.Mota; }
            set
            {
                hoaDto.Mota = value;
                RaisePropertyChanged("Mota");
            }
        }
        public double Gia
        {
            get { return hoaDto.Gia; }
            set
            {
                hoaDto.Gia = value;
                RaisePropertyChanged("Gia");
            }
        }
    }
}

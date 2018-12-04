using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using AppLetGo.DAL;
using Xamarin.Forms;

namespace AppLetGo.ViewModels
{
    class LoaiHoaViewModel : INotifyPropertyChanged
    {
        private Loaihoa loaihoa;
        ObservableCollection<Loaihoa> loaihoalist;
        public ILoaiHoaRepository loaihoaRepository;
        public ICommand AddLoaiHoa { get; private set; }
        public ICommand UpdateLoaiHoa { get; private set; }
        public ICommand DeleteLoaiHoa { get; private set; }
        public ICommand SelectLoaihoa { get; private set; }
        public LoaiHoaViewModel()
        {
            loaihoaRepository = new LoaiHoaRepository();
            LoadLoaihoa();
            AddLoaiHoa = new Command(Insert);
            UpdateLoaiHoa = new Command(Update, CanExe);
            DeleteLoaiHoa = new Command(Delete, CanExe);
            SelectLoaihoa = new Command(ChonLoaiHoa);
            loaihoa = new Loaihoa();
        }

        private void ChonLoaiHoa()
        {

        }

        private void Delete()
        {
            loaihoaRepository.DeleteAsync(loaihoa.Maloai);
            LoadLoaihoa();
        }

        private bool CanExe()
        {
            if (Loaihoa == null || Loaihoa.Maloai == 0)
                return false;
            else
                return true;
        }
       
        private void Update()
        {
            loaihoaRepository.Update(Loaihoa);
            LoadLoaihoa();
        }

        public Loaihoa Loaihoa
        {
            get { return loaihoa; }
            set
            {
                loaihoa = value;
                RaisePropertyChanged("Loaihoa");
                ((Command)UpdateLoaiHoa).ChangeCanExecute();

            }
        }
        private void Insert()
        {
            loaihoaRepository.InsertAsync(loaihoa);
            LoadLoaihoa();
        }

        public int ID
        {
            get { return loaihoa.Maloai; }
            set
            {
                loaihoa.Maloai = value;
                RaisePropertyChanged("ID");
            }
        }
        public string Tenloai
        {
            get { return loaihoa.Tenloai; }
            set
            {
                loaihoa.Tenloai = value;
                RaisePropertyChanged("Tenloai");
            }
        }


        public ObservableCollection<Loaihoa> Loaihoalist
        {
            get { return loaihoalist; }
            set
            {
                loaihoalist = value;
                RaisePropertyChanged("Loaihoalist");
            }
        }
        void LoadLoaihoa()
        {
            Loaihoalist = loaihoaRepository.GetAll();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}

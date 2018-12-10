using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppLetGo.Business;
using AppLetGo.DAL;
using Xamarin.Forms;

namespace AppLetGo
{
    public class LoaiHoaViewModel : INotifyPropertyChanged
    {
        private LoaiHoaDto loaihoa;
        ObservableCollection<LoaiHoaDto> loaihoalist;
        public LoaiHoaService loaiHoaService;
        public ICommand AddLoaiHoa { get; private set; }
        public ICommand UpdateLoaiHoa { get; private set; }
        public ICommand DeleteLoaiHoa { get; private set; }
        public ICommand SelectLoaihoa { get; private set; }
        public LoaiHoaViewModel()
        {
            loaiHoaService = new LoaiHoaService();
            Task.Run(() => LoadLoaihoaAsync()); 
            AddLoaiHoa = new Command(async () => await Insert());
            UpdateLoaiHoa = new Command(async () => await Update(), CanExe);
            DeleteLoaiHoa = new Command(async () => await Delete(), CanExe);
            SelectLoaihoa = new Command(ChonLoaiHoa);
            loaihoa = new LoaiHoaDto();
        }

        private void ChonLoaiHoa()
        {

        }

        private async Task Delete()
        {
            await loaiHoaService.Delete(loaihoa.Maloai);
            await LoadLoaihoaAsync();
        }

        private bool CanExe()
        {
            if (Loaihoa == null || Loaihoa.Maloai == 0)
                return false;
            else
                return true;
        }
       
        private async Task Update()
        {
            await loaiHoaService.Update(Loaihoa);
            await LoadLoaihoaAsync();
        }

        public LoaiHoaDto Loaihoa
        {
            get { return loaihoa; }
            set
            {
                loaihoa = value;
                RaisePropertyChanged("Loaihoa");
                ((Command)UpdateLoaiHoa).ChangeCanExecute();

            }
        }
        private async Task Insert()
        {
            await loaiHoaService.Insert(loaihoa);
            await LoadLoaihoaAsync();
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


        public ObservableCollection<LoaiHoaDto> Loaihoalist
        {
            get { return loaihoalist; }
            set
            {
                loaihoalist = value;
                RaisePropertyChanged("Loaihoalist");
            }
        }
        public async Task LoadLoaihoaAsync()
        {
            var result = await loaiHoaService.GetLoaiHoas();
            Loaihoalist = new ObservableCollection<LoaiHoaDto>(result);
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}

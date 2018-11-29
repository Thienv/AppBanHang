using AppLetGo.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLetGo.Business
{
    public interface IHoaService
    {
        void Delete(Hoa hoa);
        ObservableCollection<Hoa> GetHoas();
        Hoa GetHoasById(int Mahoa);
        ObservableCollection<Hoa> GetHoasByLoai(int Maloai);
        void Insert(Hoa hoa);
        void Update(Hoa hoa);
    }
    public class HoaService : IHoaService
    {
        IHoaRepository _hoaRepository;
        IContext context;
        public HoaService()
        {
            this._hoaRepository = new HoaRepository(context);
        }
        public void Delete(Hoa hoa)
        {
            this._hoaRepository.Delete(hoa);
        }

        public ObservableCollection<Hoa> GetHoas()
        {
            return this._hoaRepository.GetAll();
        }

        public Hoa GetHoasById(int Mahoa)
        {
            return this._hoaRepository.GetById(Mahoa);
        }

        public ObservableCollection<Hoa> GetHoasByLoai(int Maloai)
        {
            throw new NotImplementedException();
        }

        public void Insert(Hoa hoa)
        {
            this._hoaRepository.Insert(hoa);
        }

        public void Update(Hoa hoa)
        {
            this._hoaRepository.Update(hoa);
        }
    }
}

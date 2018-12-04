using AppLetGo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLetGo.Business
{
    public interface ILoaiHoaService
    {
        Task Delete(Loaihoa loaihoa);

        Task Insert(Loaihoa loaihoa);

        void Update(Loaihoa loaihoa);

        Task<LoaiHoaDto> GetHoasById(int Mahoa);

        Task<List<LoaiHoaDto>> GetLoaiHoas();
        
    }
    public class LoaiHoaService : ILoaiHoaService
    {
        ILoaiHoaRepository _loaiHoaRepository;
        IContext context;
        public LoaiHoaService()
        {
            this._loaiHoaRepository = new LoaiHoaRepository(context);
        }
        public Task Delete(Loaihoa loaihoa)
        {
            throw new NotImplementedException();
        }

        public Task<LoaiHoaDto> GetHoasById(int Mahoa)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LoaiHoaDto>> GetLoaiHoas()
        {
            var result = await _loaiHoaRepository.GetAll();
            return result.Select(x => new LoaiHoaDto
            {
                Maloai = x.Maloai,
                Tenloai = x.Tenloai
            }).ToList(); 
        }

        public async Task Insert(Loaihoa loaihoa)
        {

            await Task.Run(() => _loaiHoaRepository.InsertAsync(loaihoa));
        }

        public void Update(Loaihoa loaihoa)
        {
            throw new NotImplementedException();
        }
    }
}

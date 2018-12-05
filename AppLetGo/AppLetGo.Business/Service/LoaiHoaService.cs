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
        Task<bool> Delete(int id);

        Task<bool> Insert(LoaiHoaDto loaihoa);

        Task<bool> Update(LoaiHoaDto loaihoa);

        Task<LoaiHoaDto> GetLoaiHoasById(int Mahoa);

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
        public async Task<bool> Delete(int id)
        {
            bool flat = await _loaiHoaRepository.DeleteAsync(id);
            return flat;
        }

        public async Task<LoaiHoaDto> GetLoaiHoasById(int maloai)
        {
            var result = await _loaiHoaRepository.GetByIdAsync(maloai);
            return new LoaiHoaDto
            {
                Maloai = result.Maloai,
                Tenloai = result.Tenloai
            };
            
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

        public async Task<bool> Insert(LoaiHoaDto loaihoa)
        {

            bool flat = await _loaiHoaRepository.InsertAsync(new Loaihoa {
                Maloai = loaihoa.Maloai,
                Tenloai = loaihoa.Tenloai
            });
            return flat;
        }

        public Task<bool> Update(LoaiHoaDto loaihoa)
        {
            throw new NotImplementedException();
        }
    }
}

﻿using AppLetGo.DAL;
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
        Task<bool> Delete(int id);

        Task<bool> Insert(Hoa hoa);

        Task<bool> Update(Hoa hoa);
        Task<List<HoaDto>> GetHoasAsync();

        Task<HoaDto> GetHoasByIdAsync(int Mahoa);

        Task<List<HoaDto>> GetHoasByLoai(int Maloai);

        
    }
    public class HoaService : IHoaService
    {
        IHoaRepository _hoaRepository;
        IContext context;
        public HoaService()
        {
            context = new DataContext();
            this._hoaRepository = new HoaRepository(context);
        }
        public async Task<bool> Delete(int id)
        {
            return  await this._hoaRepository.DeleteAsync(id);
        }

        public async Task<List<HoaDto>> GetHoasAsync()
        {
            var result = await this._hoaRepository.GetAll();
            
            return result.Select(x => new HoaDto
            {
                Gia = x.Gia,
                Hinh = x.Hinh,
                Mahoa = x.Mahoa,
                Maloai = x.Maloai,
                Mota = x.Mota,
                Tenhoa = x.Tenhoa
            }).ToList();
        }

        public async Task<HoaDto> GetHoasByIdAsync(int Mahoa)
        {
            var result = await this._hoaRepository.GetByIdAsync(Mahoa);
            return new HoaDto
            {
                Tenhoa = result.Tenhoa,
                Mota = result.Mota,
                Maloai = result.Maloai,
                Gia = result.Gia,
                Hinh = result.Hinh,
                Mahoa = result.Mahoa
            };
        }        

        public async Task<bool> Insert(Hoa hoa)
        {
            return await this._hoaRepository.InsertAsync(hoa);
        }

        public async Task<bool> Update(Hoa hoa)
        {
           return await this._hoaRepository.Update(hoa);
        }

        async Task<List<HoaDto>> IHoaService.GetHoasByLoai(int Maloai)
        {
            var result = await this._hoaRepository.GetFillterAsync(x => x.Maloai == Maloai);
            return result.Select(x => new HoaDto
            {
                Gia = x.Gia,
                Hinh =x.Hinh,
                Mahoa = x.Mahoa,
                Maloai = x.Maloai,
                Mota =x.Mota,
                Tenhoa = x.Tenhoa
            }).ToList();
        }
    }
}

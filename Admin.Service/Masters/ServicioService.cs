using Admin.DTO;
using Admin.Entities.Models;
using Admin.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;

        public ServicioService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
        }

        public async Task<List<ServiciosDTO>> GetAll()
        {
            var data = await _unitOfWork.ServicioRepository.GetAllAsync();
            return _mapper.Map<List<ServiciosDTO>>(data);
        }
        public async Task Add(CreateServicioDTO dto)
        {
            var data = await _unitOfWork.ServicioRepository.GetOne(x => x.Nombre == dto.Nombre);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Servicio>(dto);
            _unitOfWork.ServicioRepository.Add(entity);
            await _unitOfWork.SaveChanges();
        }
        public async Task Update(ServiciosDTO dto)
        {
            var data = await _unitOfWork.ServicioRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.ServicioRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChanges();
        }
        public async Task Delete(int id)
        {
            var data = await _unitOfWork.ServicioRepository.GetOne(x => x.Id == id);
            if (data == null)
            {
                return;
            }
            _unitOfWork.ServicioRepository.DeleteAsync(data);
            await _unitOfWork.SaveChanges();
        }
    }
}

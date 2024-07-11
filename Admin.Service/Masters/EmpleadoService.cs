using Admin.DTO;
using Admin.Entities.Modelos;
using Admin.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;

        public EmpleadoService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
        }

        public async Task<List<EmpleadosDTO>> GetAll()
        {
            var data = await _unitOfWork.EmpleadosRepository.GetAllAsync();
            return _mapper.Map<List<EmpleadosDTO>>(data);
        }
        public async Task Add(CreateEmpleadoDTO dto)
        {
            var data = await _unitOfWork.EmpleadosRepository.GetOne(x => x.NumeroDocumento == dto.NumeroDocumento);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Empleado>(dto);
            _unitOfWork.EmpleadosRepository.Add(entity);
            await _unitOfWork.SaveChanges();
        }
        public async Task Update(EmpleadosDTO dto)
        {
            var data = await _unitOfWork.EmpleadosRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.EmpleadosRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChanges();
        }
        public async Task Delete(EmpleadosDTO dto)
        {
            var data = await _unitOfWork.EmpleadosRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<Empleado>(dto);
            _unitOfWork.EmpleadosRepository.DeleteAsync(entity);
            await _unitOfWork.SaveChanges();
        }
    }
}

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
    public class CecoService : ICecoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;

        public CecoService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
        }

        public async Task<List<CecoDTO>> GetAll()
        {
            var data = await _unitOfWork.CecoRepository.GetAllAsync();
            return _mapper.Map<List<CecoDTO>>(data);
        }
        public async Task Add(CreateCecoDTO dto)
        {
            var data = await _unitOfWork.CecoRepository.GetOne(x => x.Nombre == dto.Nombre);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Ceco>(dto);
            _unitOfWork.CecoRepository.Add(entity);
            await _unitOfWork.SaveChanges();
        }
        public async Task Update(CecoDTO dto)
        {
            var data = await _unitOfWork.CecoRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.CecoRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChanges();
        }
        public async Task Delete(CecoDTO dto)
        {
            var data = await _unitOfWork.CecoRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<Ceco>(dto);
            _unitOfWork.CecoRepository.DeleteAsync(entity);
            await _unitOfWork.SaveChanges();
        }
    }
}

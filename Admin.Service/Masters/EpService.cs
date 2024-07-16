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
    public class EpService : IEpService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;

        public EpService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
        }

        public async Task<List<GenericDTO>> GetAll()
        {
            var data = await _unitOfWork.EpRepository.GetAllAsync();
            return _mapper.Map<List<GenericDTO>>(data);
        }
        public async Task Add(CreateGenericDTO dto)
        {
            var data = await _unitOfWork.EpRepository.GetOne(x => x.Nombre == dto.Nombre);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Ep>(dto);
            _unitOfWork.EpRepository.Add(entity);
            await _unitOfWork.SaveChanges();
        }
        public async Task Update(GenericDTO dto)
        {
            var data = await _unitOfWork.EpRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.EpRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChanges();
        }
        public async Task Delete(int id)
        {
            var data = await _unitOfWork.EpRepository.GetOne(x => x.Id == id);
            if (data == null)
            {
                return;
            }
            _unitOfWork.EpRepository.DeleteAsync(data);
            await _unitOfWork.SaveChanges();
        }
    }
}

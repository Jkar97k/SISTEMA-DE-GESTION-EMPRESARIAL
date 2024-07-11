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
    public class EpService : IEpService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;

        public EpService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
        }

        public async Task<List<EpDTO>> GetAll()
        {
            var data = await _unitOfWork.EpRepository.GetAllAsync();
            return _mapper.Map<List<EpDTO>>(data);
        }
        public async Task Add(CreateEpDTO dto)
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
        public async Task Update(EpDTO dto)
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
        public async Task Delete(EpDTO dto)
        {
            var data = await _unitOfWork.EpRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<Ep>(dto);
            _unitOfWork.EpRepository.DeleteAsync(entity);
            await _unitOfWork.SaveChanges();
        }
    }
}

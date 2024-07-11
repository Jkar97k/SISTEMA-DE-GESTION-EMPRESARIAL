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
    public class FondosPensionService : IFondosPensionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;

        public FondosPensionService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
        }

        public async Task<List<FondosPensionDTO>> GetAll()
        {
            var data = await _unitOfWork.FondosPensionRepository.GetAllAsync();
            return _mapper.Map<List<FondosPensionDTO>>(data);
        }
        public async Task Add(CreateFondosPension dto)
        {
            var data = await _unitOfWork.FondosPensionRepository.GetOne(x => x.Nombre == dto.Nombre);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<FondosPensione>(dto);
            _unitOfWork.FondosPensionRepository.Add(entity);
            await _unitOfWork.SaveChanges();
        }
        public async Task Update(FondosPensionDTO dto)
        {
            var data = await _unitOfWork.FondosPensionRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.FondosPensionRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChanges();
        }
        public async Task Delete(FondosPensionDTO dto)
        {
            var data = await _unitOfWork.FondosPensionRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<FondosPensione>(dto);
            _unitOfWork.FondosPensionRepository.DeleteAsync(entity);
            await _unitOfWork.SaveChanges();
        }
    }
}

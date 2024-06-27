using Admin.DTO.Masters;
using Admin.Entities.Modelos;
using Admin.Interfaces.Repositories.Repositories;
using Admin.Repositories.Base;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Services.Masters
{
    public class CargoService : ICargoService
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public CargoService(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(CreateCargoDTO dto)
        {
            var data = await _unitOfWork.CargoRepository.GetOne(x => x.Nombre == dto.Nombre);

            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Cargo>(dto);
           await _unitOfWork.CargoRepository.AddAsync(entity);
           await _unitOfWork.SaveChanges();
        }

        public async Task<List<CargoDTO>> GetAllAsync()
        {
            var data = await _unitOfWork.CargoRepository.GetAllAsync();
            return _mapper.Map<List<CargoDTO>>(data);
        }

        public async Task Update(CargoDTO dto)
        {
            var dataG = await _unitOfWork.CargoRepository.GetOne(x => x.Id == dto.Id);


            if (dataG == null)
            {
                return;
            }
            var dataN = await _unitOfWork.CargoRepository.GetOne(x => x.Nombre == dto.Nombre);

            if (dataN != null)
            {
                return;
            }

            var user = _mapper.Map(dto, dataG);

            _unitOfWork.CargoRepository.UpdateAsync(user);

            await _unitOfWork.SaveChanges();
            return;
        }

        public async Task Delete(CargoDTO dto) 
        {
            var dataG = await _unitOfWork.CargoRepository.GetOne(x => x.Id == dto.Id);

            if (dataG != null)
            {
                return;
            }
            
            var entity = _mapper.Map<Cargo>(dto);

            _unitOfWork.CargoRepository.DeleteAsync(entity);

            await _unitOfWork.SaveChanges();
        }

    }
}

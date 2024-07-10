using Admin.DTO.Masters.Cargo;
using Admin.Entities.Modelos;
using Admin.Interfaces.Repositories.Repositories;
using Admin.Repositories.Base;
using AutoMapper;
using Microsoft.Extensions.Logging;
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
        //private readonly ILogger<CargoService> _logger;

        public CargoService(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_logger = logger;
        }

        public async Task Create(CreateCargoDTO dto)
        {
            var data = await _unitOfWork.CargoRepository.GetOne(x => x.Nombre == dto.Nombre);

            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Cargo>(dto);
            _unitOfWork.CargoRepository.Add(entity);
           await _unitOfWork.SaveChanges();
        }

        public async Task<List<CargoDTO>> GetAllAsync()
        {
            //_logger.LogInformation("Este mensaje es para el logger");
            var data = await _unitOfWork.CargoRepository.GetAllAsync();


            //_logger.LogError("Error al crear la orden de trabajo"); // Registrar el mensaje de error
            //throw new Exception("Error al crear la orden de trabajo");
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

            if (dataG == null)
            {
                return;
            }
            
            var entity = _mapper.Map<Cargo>(dto);

            _unitOfWork.CargoRepository.DeleteAsync(entity);

            await _unitOfWork.SaveChanges();
        }

    }
}

﻿using Admin.DTO;
using Admin.Entities.Models;
using Admin.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Services
{
    public class CargoService : ICargoService
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CargoService> _logger;

        public CargoService(IUnitofWork unitOfWork, IMapper mapper, ILogger<CargoService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _logger = logger;
        }

        public async Task Create(CreateGenericDTO dto)
        {
            try 
            {
                var data = await _unitOfWork.CargoRepository.GetOne(x => x.Nombre == dto.Nombre);

                if (data != null)
                {
                    _logger.LogWarning("Ya Existe en la base de Datos");
                    return;
                }
                var entity = _mapper.Map<Cargo>(dto);
                await _unitOfWork.CargoRepository.Add(entity);
                await _unitOfWork.SaveChanges();
                _logger.LogInformation("Se a Creado con Exito El Cargo");
            } 
            catch 
            {
                _logger.LogError("Error al ejecutar ");
            }

        }

        public async Task<List<GenericDTO>> GetAllAsync()
        {
            //_logger.LogInformation("Este mensaje es para el logger");
            var data = await _unitOfWork.CargoRepository.GetAllAsync();


            //_logger.LogError("Error al crear la orden de trabajo"); // Registrar el mensaje de error
            //throw new Exception("Error al crear la orden de trabajo");
            return _mapper.Map<List<GenericDTO>>(data);
        }

        public async Task Update(GenericDTO dto)
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

        public async Task Delete(int id)
        {
            var dataG = await _unitOfWork.CargoRepository.GetOne(x => x.Id == id);

            if (dataG == null)
            {
                return;
            }
  
            _unitOfWork.CargoRepository.DeleteAsync(dataG);

            await _unitOfWork.SaveChanges();
        }

    }
}

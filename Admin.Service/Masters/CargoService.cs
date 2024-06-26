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
            var transaccion = _unitOfWork.BeginTransaction();
            try
            {
                var entity = _mapper.Map<Cargo>(dto);
                _unitOfWork.CargoRepository.AddAsync(entity);
                transaccion.Commit();
                _unitOfWork.Commit();
            }
            catch
            {
                transaccion.Rollback();
            }
        }

    }
}

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
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;

        public EmpleadoService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
        }
        public async Task CreateEmpleado(RequestCreateEmpleado request)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var data = await _unitOfWork.EmpleadosRepository.GetOne(x => x.NumeroDocumento == request.Empleado.NumeroDocumento);
                    if (data != null)
                    {
                        return;
                    }
                    var empleadoDT = _mapper.Map<Empleado>(request.Empleado);
                    empleadoDT.Guid = Guid.NewGuid().ToString();
                    empleadoDT.Created = DateTime.Now;
                    empleadoDT.ModifiedBy = "JKAr";
                    empleadoDT.ModifiedDate = DateTime.Now;
                    empleadoDT.Status = true;
                    await _unitOfWork.EmpleadosRepository.Add(empleadoDT);
                    await _unitOfWork.SaveChanges();

                    var contrato = _mapper.Map<ContratosLaborale>(request.ContratosLaborale);
                    contrato.EmpleadoId = empleadoDT.Id;
                    await _unitOfWork.ContratosLaboraleRepository.Add(contrato);
                    await _unitOfWork.SaveChanges();

                    //ActivarEmpleado(request);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public async Task<List<RequestEmpleado>> GetToAll()
        {
            var empleadosData = await _unitOfWork.EmpleadosRepository.GetAllAsync();
            var contratosData = await _unitOfWork.ContratosLaboraleRepository.GetAllAsync();

            var empleados = _mapper.Map<List<EmpleadosDTO>>(empleadosData);
            var contratos = _mapper.Map<List<ContratosLaboralesDTO>>(contratosData);

            var contratosPorEmpleadoId = contratos.ToDictionary(c => c.EmpleadoId);

            var result = new List<RequestEmpleado>();

            foreach (var empl in empleados)
            {
                if (contratosPorEmpleadoId.TryGetValue(empl.Id, out var contrato))
                {
                    var requestempleado = new RequestEmpleado
                    {
                        EmpleadoDT = empl,
                        ContratosLaborales = contrato
                    };
                    result.Add(requestempleado);
                }
            }
            return result;
        }
    }
}

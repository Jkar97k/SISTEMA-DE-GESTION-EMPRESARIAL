using Admin.DTO;
using Admin.DTO.BacklogsEvent;
using Admin.Entities.Models;
using Admin.Interfaces;
using Admin.Interfaces.ServiceCall;
using AutoMapper;
using DTO;
using DTO.BacklogsEvent;
using System.Diagnostics.Contracts;
using System.Text.Json;

namespace Admin.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;
        private readonly IAuthService _authService;

        public EmpleadoService(IMapper mapper, IUnitofWork unitofWork, IAuthService authService)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
            _authService = authService;
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

                    var responseAuth = new RequestActivarEmpleado
                    (
                      request.Empleado.NumeroDocumento,
                       request.Empleado.CorreoPersonal,
                      request.ContratosLaborale.CargoId
                    );

                    await ActivarEmpleado(responseAuth);

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

        public async Task UpdateEmpleado(RequestEmpleado request)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var data = await _unitOfWork.EmpleadosRepository.GetOne(x => x.NumeroDocumento == request.EmpleadoDT.NumeroDocumento);
                    if (data == null)
                    {
                        return;
                    }
                    var empleadoDT = _mapper.Map(request.EmpleadoDT, data);
                    empleadoDT.ModifiedBy = "JKAr";
                    empleadoDT.ModifiedDate = DateTime.Now;
                    _unitOfWork.EmpleadosRepository.UpdateAsync(empleadoDT);
                    await _unitOfWork.SaveChanges();

                    var dataC = await _unitOfWork.ContratosLaboraleRepository.GetOne(x => x.EmpleadoId == request.EmpleadoDT.Id);
                    if (dataC == null)
                    {
                        return;
                    }
                    
                    var contrato = _mapper.Map(request.ContratosLaborales, dataC);
                    contrato.EmpleadoId = empleadoDT.Id;
                    //contrato.Id = dataC.Id;
                    _unitOfWork.ContratosLaboraleRepository.UpdateAsync(contrato);
                    await _unitOfWork.SaveChanges();

                    if (empleadoDT.Status == false)
                    {
                        var reponseAuth = new RequestDesactivarEmpleado(
                            request.EmpleadoDT.NumeroDocumento,
                            DateTime.Now
                            );

                        await DarBajaEmpleado(reponseAuth);
                    }


                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public async Task ActivarEmpleado(RequestActivarEmpleado request) 
        {
            var backlog = new BacklogsEventDTO()
            {
                CreatedAt = DateTime.Now,
                EventType = (int)EventsEnum.DarAltaEmpleado,
                Json = JsonSerializer.Serialize(request)
            };
            var back = _mapper.Map<BacklogsEvent>(backlog);
            await _unitOfWork.BacklLogsRepository.Add(back);
            await _unitOfWork.SaveChanges();
        }
        public async Task DarBajaEmpleado(RequestDesactivarEmpleado request) 
        {
            await _authService.DarBajaEmpleado(request);
        }
    }
}

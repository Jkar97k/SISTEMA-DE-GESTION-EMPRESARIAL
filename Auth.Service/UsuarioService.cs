
using Auth.DTO;
using Auth.Entities.Models;
using Auth.Interfaces;
using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using DTO;
using Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;

namespace Auth.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;
        private readonly ILogger< RequestDesactivarEmpleado> _logger;
        public UsuarioService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
        }

        public async Task<List<UsuarioDTO>> GetAll()
        {
            var data = await _unitOfWork.UsuarioRepository.GetAllAsync();
            return _mapper.Map<List<UsuarioDTO>>(data);
        }


        public async Task DarAltaUsuario(RequestActivarEmpleado dtos)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try 
                {
                    var data = await _unitOfWork.UsuarioRepository.GetOne(x => x.NumeroDocumento == dtos.IdenficadorEmpleado);

                    if (data != null)
                    {
                        throw new ClientErrorException("Error en el proceso , ya existe el usuario creado");

                    }

                    var table = new CreateUsuarioDTO(
                            dtos.IdenficadorEmpleado,
                            dtos.Correo,
                            dtos.IdenficadorEmpleado,
                            dtos.Cargo,
                            Guid.NewGuid().ToString(),
                            DateTime.Now,
                            null,
                            true
                        );
                    var entity = _mapper.Map<Usuario>(table);
                    await _unitOfWork.UsuarioRepository.Add(entity);
                    await _unitOfWork.SaveChanges();
                    transaction.Commit();
                } 
                catch 
                {
                    transaction.Rollback();
                    throw new ClientErrorException("Error en el proceso , los cambios no se ejecutaron");
                }
            }
            
        }
        public async Task DarBajaEmpleado(RequestDesactivarEmpleado dtos)
        {
            var data = await _unitOfWork.UsuarioRepository.GetOne(x => x.NumeroDocumento == dtos.IdenficadorEmpleado);
            if (data == null)
            {
                return;
            }
            data.FechaDesactivacion = dtos.FechaDesactivacion;
            data.Status = false;
            _unitOfWork.UsuarioRepository.UpdateAsync(data);
            await _unitOfWork.SaveChanges();

            
        }
        //public async Task Delete(int id)
        //{
        //    var data = await _unitOfWork.UsuarioRepository.GetOne(x => x.Id == id);
        //    if (data == null)
        //    {
        //        return;
        //    }
        //    _unitOfWork.UsuarioRepository.DeleteAsync(data);
        //    await _unitOfWork.SaveChanges();
        //}
    }
}

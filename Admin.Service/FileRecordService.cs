using Admin.DTO;
using Admin.Entities.Models;
using Admin.Interfaces;
using AutoMapper;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Services
{
    public class FileRecordService : IFileRecordService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;
        private readonly IManejadorDeArchivosLocal _manejadorArchivos;

        public FileRecordService(IMapper mapper, IUnitofWork unitofWork, IManejadorDeArchivosLocal manejadorArchivos)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
            _manejadorArchivos = manejadorArchivos;
        }

        public async Task UploadFile(CreateFileRecordDTO dto, byte[] content)
        {
            using (var transaction = _unitOfWork.BeginTransaction()) 
            {
                try
                {
                    var data = await _unitOfWork.FileRecordRepository.GetOne(x => x.IdentificadorEmpleado == dto.IdentificadorEmpleado && x.ContentType == dto.ContentType);

                    var entity = _mapper.Map<FileRecord>(dto);
                    await _unitOfWork.FileRecordRepository.Add(entity);
                    await _unitOfWork.SaveChanges();

                    await _unitOfWork.ContratosLaboraleRepository.ActualizarRefContrato(dto.ContentType,dto.Nombre,dto.IdentificadorEmpleado);
                    await _unitOfWork.SaveChanges();

                    if (data != null)
                    {
                        _unitOfWork.FileRecordRepository.DeleteAsync(data);
                        await _unitOfWork.SaveChanges();
                        _manejadorArchivos.DeleteFile(data.Ruta);

                    }
                    await _manejadorArchivos.GuardarFile(dto.Ruta, content);

                    transaction.Commit();



                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }

        }
    }
}

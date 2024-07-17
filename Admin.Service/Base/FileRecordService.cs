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

        public async Task UploadFile(CreateFileRecordDTO dto)
        {
            var data = await _unitOfWork.FileRecordRepository.GetOne(x => x.IdentificadorEmpleado == dto.IdentificadorEmpleado && x.ContentType == dto.ContentType);
            if (data != null)
            {
                _manejadorArchivos.DeleteFile(data.Ruta);
                _unitOfWork.FileRecordRepository.DeleteAsync(data);
            }
            var entity = _mapper.Map<FileRecord>(dto);
            await _unitOfWork.FileRecordRepository.Add(entity);
            await _unitOfWork.SaveChanges();
        }
    }
}

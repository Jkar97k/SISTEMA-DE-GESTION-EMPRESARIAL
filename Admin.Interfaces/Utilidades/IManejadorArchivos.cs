using Admin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Interfaces.Utilidades
{
    public interface IManejadorArchivos
    {
        Task<CreateFileRecordDTO> GuardarArchivo(byte[] contenido, string nombreArchivo, string contentType, string bucket);
        Task<byte[]> ObtenerArchivo(string ruta, string bucket);
        Task<string> ObtenerArchivoEnBase64(string ruta, string bucket);
    }
}

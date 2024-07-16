using Admin.DTO;
using Admin.Interfaces.Utilidades;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class ManejadorDeArchivosLocal : IManejadorArchivos
    {
        private readonly string _carpetaBase;

        public ManejadorDeArchivosLocal(IWebHostEnvironment env)
        {
            _carpetaBase = env.WebRootPath;
        }

        public async Task<CreateFileRecordDTO> GuardarArchivo(byte[] contenido, string nombreArchivo, string contentType, string bucket)
        {
            var carpetaDestino = Path.Combine(_carpetaBase, bucket);

            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            var extension = Path.GetExtension(nombreArchivo);
            var guid = Guid.NewGuid().ToString();
            var nombreArchivoConGuid = guid + extension;
            var rutaArchivo = Path.Combine(carpetaDestino, nombreArchivoConGuid);

            await File.WriteAllBytesAsync(rutaArchivo, contenido);

            var fileRecord = new CreateFileRecordDTO
            {
                Nombre = nombreArchivoConGuid,
                ContentType = contentType,
                Bucket = bucket,
                Guid = guid
            };

            return fileRecord;
        }

        public async Task<byte[]> ObtenerArchivo(string bucket, string nombreArchivo)
        {
            return await File.ReadAllBytesAsync(GenerarRutaArchivo(bucket, nombreArchivo));
        }

        public async Task<string> ObtenerArchivoEnBase64(string bucket, string nombreArchivo)
        {
            var bytes = await File.ReadAllBytesAsync(GenerarRutaArchivo(bucket, nombreArchivo));
            return Convert.ToBase64String(bytes);
        }

        private string GenerarRutaArchivo(string bucket, string nombreArhivo)
        {
            var carpeta = Path.Combine(_carpetaBase, bucket);
            return Path.Combine(carpeta, nombreArhivo);
        }
    }
}

using Admin.DTO;
using Admin.Interfaces;
using Admin.Interfaces.Utilidades;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class ManejadorDeArchivosLocal : IManejadorDeArchivosLocal
    {
        private readonly string _carpetaBase;

        public ManejadorDeArchivosLocal(IWebHostEnvironment env)
        {
            _carpetaBase = env.WebRootPath;
        }

        public CreateFileRecordDTO GuardarArchivo(string nombreArchivo, string bucket, string idenficadorEmpleado, int contentTypeuser)
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

            var fileRecord = new CreateFileRecordDTO
            {
                IdentificadorEmpleado = idenficadorEmpleado,
                Nombre = nombreArchivoConGuid,
                ContentType = contentTypeuser,
                Ruta = rutaArchivo,
                Guid = guid
            };

            return fileRecord;
        }


        public async Task GuardarFile(string rutaArchivo, byte[] contenido)
        {
            await File.WriteAllBytesAsync(rutaArchivo, contenido);
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

        public void DeleteFile(string rutaArchivoCompleta)
        {
            try
            {
                if (System.IO.File.Exists(rutaArchivoCompleta))
                {
                    System.IO.File.Delete(rutaArchivoCompleta);
                }
                else
                {
                    throw new FileNotFoundException($"El archivo no existe en la ruta especificada: {rutaArchivoCompleta}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el archivo '{rutaArchivoCompleta}': {ex.Message}");
            }
        }
    }
}

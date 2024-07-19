using Admin.DTO;

namespace Interfaces
{
    public interface IManejadorDeArchivosLocal
    {
        void DeleteFile(string rutaArchivoCompleta);
        CreateFileRecordDTO GuardarArchivo(string nombreArchivo, string bucket, string idenficadorEmpleado, int contentTypeuser);
        Task GuardarFile(string rutaArchivo, byte[] contenido);
        Task<byte[]> ObtenerArchivo(string bucket, string nombreArchivo);
        Task<string> ObtenerArchivoEnBase64(string bucket, string nombreArchivo);
    }
}
using Admin.DTO;
using Admin.DTO.utilities;

namespace Admin.Interfaces
{
    public interface IEmpleadoService
    {
        Task ActivarEmpleado(RequestActivarEmpleado request);
        Task CreateEmpleado(RequestCreateEmpleado request);
        Task DarBajaEmpleado(RequestDesactivarEmpleado request);
        Task<List<RequestEmpleado>> GetToAll();
        Task UpdateEmpleado(RequestEmpleado request);
    }
}
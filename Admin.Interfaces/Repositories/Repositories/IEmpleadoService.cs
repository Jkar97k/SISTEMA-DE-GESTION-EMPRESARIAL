using Admin.DTO;

namespace Admin.Services
{
    public interface IEmpleadoService
    {
        Task CreateEmpleado(RequestCreateEmpleado request);
        Task<List<RequestEmpleado>> GetToAll();
    }
}
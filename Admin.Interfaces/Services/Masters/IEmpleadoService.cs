using Admin.DTO;

namespace Admin.Interfaces
{
    public interface IEmpleadoService
    {
        Task Add(CreateEmpleadoDTO dto);
        Task Delete(EmpleadosDTO dto);
        Task<List<EmpleadosDTO>> GetAll();
        Task Update(EmpleadosDTO dto);
    }
}
using Admin.DTO;

namespace Admin.Interfaces
{
    public interface IServicioService
    {
        Task Add(CreateServicioDTO dto);
        Task Delete(ServiciosDTO dto);
        Task<List<ServiciosDTO>> GetAll();
        Task Update(ServiciosDTO dto);
    }
}
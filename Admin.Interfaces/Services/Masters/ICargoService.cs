using Admin.DTO.Masters;

namespace Admin.Services.Masters
{
    public interface ICargoService
    {
        Task Create(CreateCargoDTO dto);
    }
}
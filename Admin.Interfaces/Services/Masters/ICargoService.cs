using Admin.DTO.Masters.Cargo;

namespace Admin.Services.Masters
{
    public interface ICargoService
    {
        Task Create(CreateCargoDTO dto);
        Task Delete(CargoDTO dto);
        Task<List<CargoDTO>> GetAllAsync();
        Task Update(CargoDTO dto);
    }
}
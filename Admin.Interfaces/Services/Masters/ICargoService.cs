using Admin.DTO;


namespace Admin.Interfaces
{
    public interface ICargoService
    {
        Task Create(CreateCargoDTO dto);
        Task Delete(CargoDTO dto);
        Task<List<CargoDTO>> GetAllAsync();
        Task Update(CargoDTO dto);
    }
}
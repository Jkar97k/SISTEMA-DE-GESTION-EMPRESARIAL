using Admin.DTO;


namespace Admin.Interfaces
{
    public interface ICargoService
    {
        Task Create(CreateGenericDTO dto);
        Task Delete(GenericDTO dto);
        Task<List<GenericDTO>> GetAllAsync();
        Task Update(GenericDTO dto);
    }
}
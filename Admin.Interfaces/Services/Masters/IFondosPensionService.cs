using Admin.DTO;

namespace Admin.Interfaces
{
    public interface IFondosPensionService
    {
        Task Add(CreateGenericDTO dto);
        Task Delete(int id);
        Task<List<GenericDTO>> GetAll();
        Task Update(GenericDTO dto);
    }
}
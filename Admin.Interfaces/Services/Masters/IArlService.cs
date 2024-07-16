using Admin.DTO;

namespace Admin.Interfaces
{
    public interface IArlService
    {
        Task Add(CreateGenericDTO dto);
        Task Delete(int id);
        Task<List<GenericDTO>> GetAll();
        Task Update(GenericDTO dto);
    }
}
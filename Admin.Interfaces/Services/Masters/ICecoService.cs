using Admin.DTO;

namespace Admin.Interfaces
{
    public interface ICecoService
    {
        Task Add(CreateGenericDTO dto);
        Task Delete(GenericDTO dto);
        Task<List<GenericDTO>> GetAll();
        Task Update(GenericDTO dto);
    }
}
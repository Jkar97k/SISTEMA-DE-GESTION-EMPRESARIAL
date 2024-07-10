using Admin.DTO;

namespace Admin.Interfaces
{
    public interface IArlService
    {
        Task Add(CreateArlDTO dto);
        Task Delete(ArlDTO dto);
        Task<List<ArlDTO>> GetAll();
        Task Update(ArlDTO dto);
    }
}
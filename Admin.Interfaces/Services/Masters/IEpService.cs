using Admin.DTO;

namespace Admin.Interfaces
{
    public interface IEpService
    {
        Task Add(CreateEpDTO dto);
        Task Delete(EpDTO dto);
        Task<List<EpDTO>> GetAll();
        Task Update(EpDTO dto);
    }
}
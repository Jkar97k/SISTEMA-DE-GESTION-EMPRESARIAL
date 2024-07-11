using Admin.DTO;

namespace Admin.Interfaces
{
    public interface ICecoService
    {
        Task Add(CreateCecoDTO dto);
        Task Delete(CecoDTO dto);
        Task<List<CecoDTO>> GetAll();
        Task Update(CecoDTO dto);
    }
}
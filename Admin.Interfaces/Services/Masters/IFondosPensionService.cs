using Admin.DTO;

namespace Admin.Interfaces
{
    public interface IFondosPensionService
    {
        Task Add(CreateFondosPension dto);
        Task Delete(FondosPensionDTO dto);
        Task<List<FondosPensionDTO>> GetAll();
        Task Update(FondosPensionDTO dto);
    }
}
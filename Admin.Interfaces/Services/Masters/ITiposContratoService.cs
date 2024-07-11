using Admin.DTO;

namespace Admin.Interfaces
{
    public interface ITiposContratoService
    {
        Task Add(CreateTiposContratoDTO dto);
        Task Delete(TiposContratoDTO dto);
        Task<List<TiposContratoDTO>> GetAll();
        Task Update(TiposContratoDTO dto);
    }
}
using Auth.DTO;

namespace Auth.Service
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> GetAll();
    }
}
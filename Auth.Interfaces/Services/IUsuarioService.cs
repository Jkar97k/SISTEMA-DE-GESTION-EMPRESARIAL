using Auth.DTO;
using DTO;

namespace Auth.Service
{
    public interface IUsuarioService
    {
        Task DarAltaUsuario(RequestActivarEmpleado dtos);
        Task DarBajaEmpleado(RequestDesactivarEmpleado dtos);
        Task<List<UsuarioDTO>> GetAll();
    }
}
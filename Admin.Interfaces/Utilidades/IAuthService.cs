using Admin.DTO;
using Admin.DTO.utilities;

namespace Admin.Interfaces
{
    public interface IAuthService
    {
        Task<BaseResponse<bool>> ActivarEmpleado(RequestActivarEmpleado request);
        Task<BaseResponse<bool>> DarBajaEmpleado(RequestDesactivarEmpleado request);
    }
}
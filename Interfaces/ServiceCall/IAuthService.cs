using DTO;

namespace Admin.Interfaces.ServiceCall
{
    public interface IAuthService
    {
        Task<BaseResponse<bool>> ActivarEmpleado(RequestActivarEmpleado request);
        Task<BaseResponse<bool>> DarBajaEmpleado(RequestDesactivarEmpleado request);
    }
}
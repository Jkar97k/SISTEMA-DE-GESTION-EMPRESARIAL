using DTO;
using System.Net;

namespace Admin.Interfaces.ServiceCall
{
    public interface IAuthService
    {
        Task<BaseResponse<HttpStatusCode>> ActivarEmpleado(RequestActivarEmpleado request);
        Task<BaseResponse<HttpStatusCode>> DarBajaEmpleado(RequestDesactivarEmpleado request);
    }
}
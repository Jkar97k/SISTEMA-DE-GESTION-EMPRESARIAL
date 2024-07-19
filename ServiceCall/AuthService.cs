using Admin.Interfaces.ServiceCall;
using DTO;
using Utilities;

namespace ServiceCall
{
    public class AuthService : HttpBase, IAuthService
    {
        public AuthService(HttpClient client) : base(client) { }


        public async Task<BaseResponse<bool>> ActivarEmpleado(RequestActivarEmpleado request)
        {
            return await Post<bool, RequestActivarEmpleado>("", request);
        }

        public async Task<BaseResponse<bool>> DarBajaEmpleado(RequestDesactivarEmpleado request)
        {
            return await Post<bool, RequestDesactivarEmpleado>("", request);
        }
    }
}

using Admin.Interfaces.ServiceCall;
using DTO;
using Microsoft.AspNetCore.Http;
using System.Net;
using Utilities;

namespace ServiceCall
{
    public class AuthService : HttpBase, IAuthService
    {
        public AuthService(HttpClient client) : base(client) { }


        public async Task<BaseResponse<bool>> ActivarEmpleado(RequestActivarEmpleado request)
        {
            return await Post<bool, RequestActivarEmpleado>("Usuario/ActivarEmpleado", request);
        }

        public async Task<BaseResponse<bool>> DarBajaEmpleado(RequestDesactivarEmpleado request)
        {
            var result = await Put<bool, RequestDesactivarEmpleado>("Usuario/DarBajaEmpleado", request);

            return result;
        }
    }
}

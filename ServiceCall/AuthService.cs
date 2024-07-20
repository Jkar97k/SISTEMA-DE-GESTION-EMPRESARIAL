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


        public async Task<BaseResponse<HttpStatusCode>> ActivarEmpleado(RequestActivarEmpleado request)
        {
            return await Post<HttpStatusCode, RequestActivarEmpleado>("", request);
        }

        public async Task<BaseResponse<HttpStatusCode>> DarBajaEmpleado(RequestDesactivarEmpleado request)
        {
            return await Post<HttpStatusCode, RequestDesactivarEmpleado>("", request);
        }
    }
}

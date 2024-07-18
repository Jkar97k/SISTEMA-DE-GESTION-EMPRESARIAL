
using Admin.DTO;
using Admin.DTO.utilities;
using Admin.Interfaces.ServiceCall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

using Admin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Interfaces.Utilidades
{
    public interface IHttpBase
    {
        Task<BaseResponse<T>> Get<T>(string uri);
        Task<BaseResponse<R>> Post<R, S>(string uri, S Element);
        Task<BaseResponse<R>> Put<R, S>(string uri, S Element);
        Task<BaseResponse<T>> Delete<T>(string uri);
    }
}

using DTO;

namespace Admin.Interfaces
{
    public interface IHttpBase
    {
        Task<BaseResponse<T>> Get<T>(string uri);
        Task<BaseResponse<R>> Post<R, S>(string uri, S Element);
        Task<BaseResponse<R>> Put<R, S>(string uri, S Element);
        Task<BaseResponse<T>> Delete<T>(string uri);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.DTO.Api
{
    public class StandardResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }

        public StandardResponse(string message, T data)
        {
            Message = message;
            Data = data;
        }
    }
}

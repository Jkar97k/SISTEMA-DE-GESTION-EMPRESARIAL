﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BaseResponse<T>
    {
        public string Message { get; set; }
        public T Result { get; set; }
         public System.Net.HttpStatusCode? StatusCode { get; set; }
    }
}

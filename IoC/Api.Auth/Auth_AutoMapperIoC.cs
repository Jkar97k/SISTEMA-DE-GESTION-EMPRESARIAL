using Configurations.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public class Auth_AutoMapperIoC
    {
        public static void ConfigureService(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Auth_Api_MappinProfile));
        }
    }
}

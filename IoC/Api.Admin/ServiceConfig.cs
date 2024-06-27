using Admin.Repositories.Base;
using Admin.Services.Masters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC.Api.Admin
{
    public class ServiceConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<IUnitofWork, UnitofWork>();

        }
    }
}

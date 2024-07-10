using Admin.Entities.Modelos;
using Admin.Interfaces.Base;
using Admin.Interfaces.Repositories.Repositories;
using Admin.Repositories.Base;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Services.Masters;
using Admin.Repositories.Repositories.Maestros;

namespace IoC.Api.Admin
{
    public class Admin_BusinessLogicIoC
    {
        public static void RepositoryService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitofWork, UnitofWork>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<ICargoRepository, CargoRepository>();
        }
        public static void ReglasNegocioService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICargoService, CargoService>();
        }

        public static void ValidacionesService(WebApplicationBuilder builder)
        {

        }

        public static void UtilidadesService(WebApplicationBuilder builder)
        {

        }

    }
}

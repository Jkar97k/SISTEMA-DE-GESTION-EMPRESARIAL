
using Admin.Interfaces;
using Admin.Repositories.Base;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Admin.Repositories.Repositories.Maestros;
using Admin.Services;

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


using Admin.Interfaces;
using Admin.Repositories.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Admin.Repositories.Repositories.Maestros;
using Admin.Services;
using Utilities;
using Admin.Repositories;
using Admin.Interfaces.ServiceCall;

namespace IoC.Api.Admin
{
    public class Admin_BusinessLogicIoC
    {
        public static void RepositoryService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitofWork, UnitofWork>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IArlRepository, ArlRepository>();
            builder.Services.AddScoped<ICargoRepository, CargoRepository>();
            builder.Services.AddScoped<ICecoRepository, CecoRepository>();
            builder.Services.AddScoped<IEmpleadosRepository, EmpleadoRepository>();
            builder.Services.AddScoped<IContratosLaboraleRepository, ContratosLaboraleRepository>();
            builder.Services.AddScoped<IEpRepository, EpRepository>();
            builder.Services.AddScoped<IFondosPensionRepository, FondosPensionRepository>();
            builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
            builder.Services.AddScoped<ITipoContratoRepository, TiposContratoRepository>();
            builder.Services.AddScoped<IFileRecordRepository, FileRecordRepository>();
        }
        public static void ReglasNegocioService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IArlService, ArlService>();
            builder.Services.AddScoped<ICargoService, CargoService>();
            builder.Services.AddScoped<ICecoService, CecoService>();
            builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
            builder.Services.AddScoped<IEpService, EpService>();
            builder.Services.AddScoped<IFondosPensionService, FondosPensionService>();
            builder.Services.AddScoped<IServicioService, ServicioService>();
            builder.Services.AddScoped<ITipoContratoRepository, TiposContratoRepository>();
            builder.Services.AddScoped<IFileRecordService, FileRecordService>();
        }

        public static void ValidacionesService(WebApplicationBuilder builder)
        {

        }

        public static void UtilidadesService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IManejadorDeArchivosLocal, ManejadorDeArchivosLocal>();
        }

        public static void HttpClientService(WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient<IAuthService, IAuthService>(service =>
            {
                service.BaseAddress = new Uri(builder.Configuration.GetSection("ApiProject").Value);
            });
        }


    }
}

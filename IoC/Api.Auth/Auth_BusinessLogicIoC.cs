
using Admin.Interfaces;
using Admin.Repositories.Base;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Admin.Repositories.Repositories.Maestros;
using Admin.Services;
using Utilities;
using Admin.Repositories;

namespace IoC
{
    public class Auth_BusinessLogicIoC
    {
        public static void RepositoryService(WebApplicationBuilder builder)
        {

        }
        public static void ReglasNegocioService(WebApplicationBuilder builder)
        {

        }

        public static void ValidacionesService(WebApplicationBuilder builder)
        {

        }

        public static void UtilidadesService(WebApplicationBuilder builder)
        {
            //builder.Services.AddScoped<IManejadorDeArchivosLocal, ManejadorDeArchivosLocal>();
        }

    }
}

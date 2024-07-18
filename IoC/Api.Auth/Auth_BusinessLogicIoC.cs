
using Admin.Interfaces;
using Admin.Repositories.Base;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Admin.Repositories.Repositories.Maestros;
using Admin.Services;
using Utilities;
using Admin.Repositories;
using Auth.Interfaces;
using Auth.Repository;

namespace IoC
{
    public class Auth_BusinessLogicIoC
    {
        public static void RepositoryService(WebApplicationBuilder builder)
        {
           builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
        public static void ReglasNegocioService(WebApplicationBuilder builder)
        {
           // builder.Services.AddScoped<IArlService, ArlService>();
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

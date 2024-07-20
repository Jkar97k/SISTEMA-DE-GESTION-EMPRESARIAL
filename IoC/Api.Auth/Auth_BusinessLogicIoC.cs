using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Auth.Interfaces;
using Auth.Repository;
using Auth.Service;

namespace IoC
{
    public class Auth_BusinessLogicIoC 
    {
        public static void RepositoryService(WebApplicationBuilder builder)
        {
           builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
           builder.Services.AddScoped<IUnitofWork, UnitofWork>();
        }
        public static void ReglasNegocioService(WebApplicationBuilder builder)
        {
           builder.Services.AddScoped<IUsuarioService, UsuarioService>();
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

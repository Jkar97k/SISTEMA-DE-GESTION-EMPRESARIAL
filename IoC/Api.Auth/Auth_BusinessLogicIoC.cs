using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Auth.Interfaces;
using Auth.Repository;
using Auth.Service;
using Admin.Interfaces.Utilidades;
using Microsoft.Extensions.Configuration;

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
        public static void ManejoCorreos(WebApplicationBuilder builder)
        {
           // builder.Services.AddScoped<IManejadorCorreosMailKit, ManejadorCorreosMailKit>();
        }
        public static void ConfigurationAppSetting(WebApplicationBuilder builder) 
        {
            //builder.Services.Configure<ManejadorCorreosMailKit>(builder.Configuration.GetSection("EmailSettings"));
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

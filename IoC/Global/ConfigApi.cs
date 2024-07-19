using Interfaces;
using Configurations.serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Utilities;

namespace IoC
{
    public class ConfigApi
    {
        public  static void ConfigBuilderServices(WebApplicationBuilder builder) 
        {

            builder.Services.AddControllers(config =>
            {
                config.Filters.Add<GlobalLoggingFilterController>();
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();
        }

        public static void UtilidadesServices(WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<IManejadorDeArchivosLocal, ManejadorDeArchivosLocal>();
        }

        public static void ConfigureApi(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

using Configurations.serilog;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Utilities;
using Repository;
using Auth.Interfaces;
using Auth.Repository;
using Hangfire;
using Hangfire.MemoryStorage;
using IoC.Api.Admin;


namespace IoC
{
    public class ConfigApi
    {
        public  static void ConfigBuilderServices(WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            builder.Services.AddHangfire(config => config.UseMemoryStorage());

            builder.Services.AddHangfireServer();

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
            app.UseHangfireDashboard();

           // Admin_HangFireConfig.ConfigureJobs(app.Services);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

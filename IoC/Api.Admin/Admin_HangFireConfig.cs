using Admin.Services.BackGroundsEvents;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Api.Admin
{
    public class Admin_HangFireConfig
    {
        public static void ConfigureJobs(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

               // recurringJobManager.AddOrUpdate<DarAltaEmpleadoBG>("DarAltaEmpleadoBG", x => x.BGExecute(), "*/50 * * * * *");
                recurringJobManager.AddOrUpdate<DarBajaEmpleadoBG>("DarBajaEmpleadoJob", x => x.BGExecute(), "*/20 * * * * *");
            }
        }
     
    }
}

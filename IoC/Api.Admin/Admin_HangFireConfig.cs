using Admin.Services.BackGroundsEvents;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC.Api.Admin
{
    public class Admin_HangFireConfig
    {
        public static void ConfigureJobs(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

                recurringJobManager.AddOrUpdate<DarAltaEmpleadoBG>("DarAltaEmpleadoBG", x => x.BGExecute(), Cron.Minutely);
                //recurringJobManager.AddOrUpdate<DarBajaEmpleadoBG>("DarBajaEmpleadoJob", x => x.BGExecute(), Cron.Minutely);
            }
        }
     
    }
}

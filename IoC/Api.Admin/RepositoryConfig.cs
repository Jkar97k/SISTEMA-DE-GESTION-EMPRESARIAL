using Admin.Interfaces.Base;
using Admin.Interfaces.Repositories.Repositories;
using Admin.Repositories.Base;
using Admin.Repositories.Repositories;
using Admin.Services.Masters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC.Api.Admin
{
    public class RepositoryConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICargoRepository, CargoRepository>();

        }
    }
}

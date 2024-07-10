using Admin.Entities.Modelos;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC.Api.Admin
{
    public class Admin_DataBaseIoC
    {
        public static void ConfigureSQLService(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<SgeAdminContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}

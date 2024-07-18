using Auth.Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public class Auth_DataBaseIoC
    {
        public static void ConfigureSQLService(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<SgeAuthContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
        }
        public static void ConfigureMySQLService(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<SgeAuthContext>(
                (DbContextOptionsBuilder options) =>
                {
                    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
        }
    }
}

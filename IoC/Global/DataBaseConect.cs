using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Global
{
    public class DataBaseConect<T>  where T : DbContext
    {
        public static void ConfigureSQLService(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<T>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
        }
        public static void ConfigureMySQLService(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<T>(
                (DbContextOptionsBuilder options) =>
                {
                    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
        }
    }
}

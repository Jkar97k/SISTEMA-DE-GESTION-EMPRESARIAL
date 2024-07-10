using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC.Global
{
    public class SerilogIoc
    {
        [Obsolete]
        public static void SQLServerLogs(WebApplicationBuilder builder)
        {
            var columnOptions = new ColumnOptions
            {
                AdditionalColumns = new List<SqlColumn>
            {
                new SqlColumn
                {
                    ColumnName = "RequestId",
                    PropertyName = "RequestId",
                    DataType = System.Data.SqlDbType.NVarChar,
                    DataLength = 50
                }
            }
            };

            columnOptions.Store.Remove(StandardColumn.Properties);
            // Opcional: remover la columna XML Properties si no la necesitas

            Log.Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
                    tableName: "Logs",
                    columnOptions: columnOptions,
                    autoCreateSqlTable: true)
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Host.UseSerilog(Log.Logger);
        }

        public static void ConfigLogSeqAndsqlServer(WebApplicationBuilder builder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            builder.Host.UseSerilog(Log.Logger);
        }
    }
}

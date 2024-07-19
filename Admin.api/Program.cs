using Configurations.serilog;
using IoC;
using IoC.Global;

var builder = WebApplication.CreateBuilder(args);

SerilogIoc.ConfigLogSeq(builder);

Admin_DataBaseIoC.ConfigureMySQLService(builder);

Admin_AutoMapperIoC.ConfigureService(builder);

Admin_BusinessLogicIoC.CargaBuilder(builder);

var app = builder.Build();

ConfigApi.ConfigureApi(app);

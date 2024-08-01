using Configurations.serilog;
using IoC;
using IoC.Api.Admin;
using IoC.Global;


var builder = WebApplication.CreateBuilder(args);

SerilogIoc.ConfigLogSeq(builder);

Auth_DataBaseIoC.ConfigureMySQLService(builder);

Auth_AutoMapperIoC.ConfigureService(builder);

Auth_BusinessLogicIoC.RepositoryService(builder);

Auth_BusinessLogicIoC.ReglasNegocioService(builder);

Auth_BusinessLogicIoC.ManejoCorreos(builder);

Auth_BusinessLogicIoC.ConfigurationAppSetting(builder);

Auth_BusinessLogicIoC.ValidacionesService(builder);

Auth_BusinessLogicIoC.UtilidadesService(builder);

ConfigApi.ConfigBuilderServices(builder);

var app = builder.Build();

ConfigApi.ConfigureApi(app);

// Configure the HTTP request pipeline.


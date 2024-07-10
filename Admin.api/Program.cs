using Admin.api.Configuration;
using Admin.Entities.Modelos;
using Admin.Interfaces.Base;
using Admin.Interfaces.Repositories.Repositories;
using Admin.Repositories.Base;
using Admin.Repositories.Repositories;
using Admin.Services.Masters;
using Configurations.serilog;
using IoC.Api.Admin;
using IoC.Global;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

SerilogIoc.ConfigLogSeqAndsqlServer(builder);

Admin_DataBaseIoC.ConfigureSQLService(builder);

Admin_AutoMapperIoC.ConfigureService(builder);

Admin_BusinessLogicIoC.RepositoryService(builder);

Admin_BusinessLogicIoC.ReglasNegocioService(builder);

Admin_BusinessLogicIoC.ValidacionesService(builder);    

Admin_BusinessLogicIoC.UtilidadesService(builder);

//Services
ServiceConfig.Configure(builder.Services);

//Repositories
RepositoryConfig.Configure(builder.Services);


// Add services to the container.
builder.Services.AddControllers(config =>
{
    config.Filters.Add<GlobalLoggingFilterController>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Admin.api;
using Admin.Entities.Models;
using Admin.Repositories.Base;
using Admin.Repositories.Repositories;
using Admin.Services.Masters;
using Configurations.serilog;
using IoC;
using IoC.Api.Admin;
using IoC.Global;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

SerilogIoc.ConfigLogSeq(builder);

Admin_DataBaseIoC.ConfigureMySQLService(builder);

Admin_AutoMapperIoC.ConfigureService(builder);

Admin_BusinessLogicIoC.RepositoryService(builder);

Admin_BusinessLogicIoC.ReglasNegocioService(builder);

Admin_BusinessLogicIoC.ValidacionesService(builder);    

Admin_BusinessLogicIoC.UtilidadesService(builder);



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

using Admin.api.Configuration;
using Admin.Entities.Modelos;
using Admin.Interfaces.Base;
using Admin.Interfaces.Repositories.Repositories;
using Admin.Repositories.Base;
using Admin.Repositories.Repositories;
using Admin.Services.Masters;
using Configurations.serilog;
using IoC.Api.Admin;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

SerilogConfig.ConfigLogSeqAndsqlServer(builder);

builder.Services.AddDbContext<SgeAdminContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Services
ServiceConfig.Configure(builder.Services);

//Repositories
RepositoryConfig.Configure(builder.Services);


// Add services to the container.
builder.Services.AddControllers();

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

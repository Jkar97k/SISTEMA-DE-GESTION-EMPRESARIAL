using Configurations.serilog;
using IoC;
using IoC.Global;


var builder = WebApplication.CreateBuilder(args);

SerilogIoc.ConfigLogSeq(builder);

Auth_DataBaseIoC.ConfigureMySQLService(builder);

Auth_AutoMapperIoC.ConfigureService(builder);

Auth_BusinessLogicIoC.RepositoryService(builder);

Auth_BusinessLogicIoC.ReglasNegocioService(builder);

Auth_BusinessLogicIoC.ValidacionesService(builder);

Auth_BusinessLogicIoC.UtilidadesService(builder);



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

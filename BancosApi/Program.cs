using BancosApi.Domain.Interfaces;
using BancosApi.Infrastructure;
using BancosApi.Infrastructure.Mapping;

var builder = WebApplication.CreateBuilder(args);

//Logs
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//Mapping
builder.Services.AddAutoMapper(typeof(MapProfile));

//Configs
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inje��o de depend�ncias
builder.Services.AddScoped<IBanksRepository, SqliteRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

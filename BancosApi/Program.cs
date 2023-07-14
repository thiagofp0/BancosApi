using BancosApi.Domain.Interfaces;
using BancosApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Logs
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

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

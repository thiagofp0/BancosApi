using BancosApi.Domain.Base.Api.Middlewares;
using BancosApi.Domain.Interfaces;
using BancosApi.Infrastructure;
using BancosApi.Infrastructure.Database;
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

//Injeção de dependências
builder.Services.AddScoped<DbConnection>();
builder.Services.AddScoped<IBanksRepository, SqlRepository>();

var app = builder.Build();

//Middlewares
app.UseMiddleware<ExceptionHandler>();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

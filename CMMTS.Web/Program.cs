using CMMTS.Application.Services;
using CMMTS.Domain.Interfaces;
using CMMTS.Infrastructure;
using CMMTS.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//aq vai o grosso
builder.Services.AddSingleton<Connection>(new Connection(configuration));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICentroDistribuicaoRepository, CentroDistribuicaoRepository>();
builder.Services.AddScoped<IRotasRepository, RotasRepository>();
builder.Services.AddScoped<IWaypointRepository, WaypointRepository>();
builder.Services.AddScoped<IHistoricoWaypointsRepository, HistoricoWaypointsRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICentroDistribuicaoService, CentroDistribuicaoService>();
builder.Services.AddScoped<IRotasService, RotasService>();
builder.Services.AddScoped<IWaypointService, WaypointService>();

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

using ApiUsuarios.BLL.Mapeos;
using ApiUsuarios.BLL.Servicios;
using ApiUsuarios.DLL;
using ApiUsuarios.DLL.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Base de datos
builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Servicios y repositorios de Usuarios
builder.Services.AddScoped<IUsuariosServicio, UsuarioServicio>();
builder.Services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();

builder.Services.AddScoped<IVehiculosServicio, VehiculosServicio>();
builder.Services.AddScoped<IVehiculosRepositorio, VehiculosRepositorio>();

// AutoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(MapeoClases));

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

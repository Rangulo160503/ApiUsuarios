using ApiUsuarios.DLL.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuarios.DLL.Repositorio
{
    public class VehiculosRepositorio : IVehiculosRepositorio
    {
        private readonly ApiContext _context;

        public VehiculosRepositorio(ApiContext context)
        {
            _context = context;
        }
        public async Task<bool> ActualizarVehiculoAsync(Vehiculo vehiculo)
        {
            var vehiculoActualizar = _context.Vehiculos.FirstOrDefault(v => v.Id == vehiculo.Id);

            if (vehiculoActualizar == null)
                return false;

            vehiculoActualizar.Marca = vehiculo.Marca;
            vehiculoActualizar.Modelo = vehiculo.Modelo;
            vehiculoActualizar.Anno = vehiculo.Anno;
            vehiculoActualizar.Precio = vehiculo.Precio;
            vehiculoActualizar.Color = vehiculo.Color;

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> AgregarVehiculoAsync(Vehiculo vehiculo)
        {
            await _context.Vehiculos.AddAsync(vehiculo);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> EliminarVehiculoAsync(int id)
        {
            var vehiculo = _context.Vehiculos.FirstOrDefault(v => v.Id == id);

            if (vehiculo == null)
                return false;

            _context.Vehiculos.Remove(vehiculo);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Vehiculo> ObtenerVehiculoPorIdAsync(int id)
        {
            var vehiculo = _context.Vehiculos.FirstOrDefault(v => v.Id == id);
            return vehiculo;
        }

        public async Task<List<Vehiculo>> ObtenerVehiculosAsync()
        {
            return await _context.Vehiculos.ToListAsync();
        }
    }
}

using ApiUsuarios.BLL.Dtos;
using ApiUsuarios.BLL.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiculosController : Controller
    {
        private readonly IVehiculosServicio _vehiculosServicio;

        public VehiculosController(IVehiculosServicio vehiculosServicio)
        {
            _vehiculosServicio = vehiculosServicio;
        }

        // GET /Vehiculos
        [HttpGet(Name = "ObtenerVehiculos")] // ObtenerTodos
        public async Task<IActionResult> ObtenerVehiculos()
        {
            var respuesta = await _vehiculosServicio.ObtenerVehiculosAsync();
            return Ok(respuesta);
        }

        // POST /Vehiculos
        [HttpPost(Name = "CrearVehiculo")] // Crear
        public async Task<IActionResult> CrearVehiculo(VehiculoDto vehiculo)
        {
            var respuesta = await _vehiculosServicio.AgregarVehiculoAsync(vehiculo);

            if (respuesta.EsError)
            {
                return BadRequest(respuesta.Mensaje);
            }

            return Ok(respuesta);
        }

        // GET /Vehiculos/5
        [HttpGet("{id}", Name = "ObtenerVehiculo")]
        public async Task<IActionResult> ObtenerVehiculo(int id)
        {
            var respuesta = await _vehiculosServicio.ObtenerVehiculoPorIdAsync(id);

            if (respuesta.Data is null)
            {
                return NotFound("Vehículo no encontrado");
            }

            return Ok(respuesta);
        }

        // DELETE /Vehiculos/5
        [HttpDelete("{id}", Name = "EliminarVehiculo")]
        public async Task<IActionResult> EliminarVehiculo(int id)
        {
            var respuesta = await _vehiculosServicio.EliminarVehiculoAsync(id);
            return Ok(respuesta);
        }

        // PUT /Vehiculos
        [HttpPut(Name = "ActualizarVehiculo")]
        public async Task<IActionResult> ActualizarVehiculo(VehiculoDto vehiculo)
        {
            var respuesta = await _vehiculosServicio.ActualizarVehiculoAsync(vehiculo);
            return Ok(respuesta);
        }
    }
}

using ApiUsuarios.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

    namespace ApiUsuarios.WEB.Controllers
    {
        public class VehiculosController : Controller
        {
            private readonly HttpClient _http;

            public VehiculosController(IHttpClientFactory factory)
            {
                _http = factory.CreateClient("api");
            }

            // GET /Usuarios (lista)
            public async Task<IActionResult> Index()
            {
            var respuesta = await _http.GetFromJsonAsync<ApiRespuesta<List<VehiculoDto>>>("Vehiculos");
            var lista = respuesta?.Resultado ?? new List<VehiculoDto>();
            return View(lista);
        }

            // GET /Usuarios/{id}
            public async Task<IActionResult> Detalle(int id)
            {
            var resp = await _http.GetFromJsonAsync<ApiRespuesta<VehiculoDto>>($"Vehiculos/{id}");
            var vehiculo = resp?.Resultado;
            if (vehiculo == null) return NotFound();
            return View(vehiculo);

        }

        // GET Crear
        public IActionResult Crear() => View(new VehiculoDto());

            // POST /Usuarios
            [HttpPost]
            public async Task<IActionResult> Crear(VehiculoDto modelo)
            {
                var resp = await _http.PostAsJsonAsync("Vehiculos", modelo);
                if (!resp.IsSuccessStatusCode) return View(modelo);
                return RedirectToAction(nameof(Index));
            }

            // GET Editar
            public async Task<IActionResult> Editar(int id)
            {
                var vehiculo = await _http.GetFromJsonAsync<VehiculoDto  >($"Vehiculos/{id}");
                if (vehiculo == null) return NotFound();
                return View(vehiculo);
            }

            // PUT /Usuarios
            [HttpPost]
            public async Task<IActionResult> Editar(VehiculoDto modelo)
            {
                var resp = await _http.PutAsJsonAsync("Vehiculos", modelo);
                if (!resp.IsSuccessStatusCode) return View(modelo);
                return RedirectToAction(nameof(Index));
            }

            // DELETE /Usuarios/{id}
            public async Task<IActionResult> Eliminar(int id)
            {
                var resp = await _http.DeleteAsync($"Vehiculos/{id}");
                return RedirectToAction(nameof(Index));
            }
        }
    }

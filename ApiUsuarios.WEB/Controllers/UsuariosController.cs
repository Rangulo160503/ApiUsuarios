using ApiUsuarios.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.WEB.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly HttpClient _http;

        public UsuariosController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("api");
        }

        // GET /Usuarios (lista)
        public async Task<IActionResult> Index()
        {
            var respuesta = await _http.GetFromJsonAsync<ApiRespuesta<List<UsuarioDto>>>("Usuarios");

            var lista = respuesta?.Resultado ?? new List<UsuarioDto>();

            return View(lista);

        }

        // GET /Usuarios/{id}
        public async Task<IActionResult> Detalle(int id)
        {
            var resp = await _http.GetFromJsonAsync<ApiRespuesta<UsuarioDto>>($"Usuarios/{id}");
            var usuario = resp?.Resultado;
            if (usuario == null) return NotFound();
            return View(usuario);

        }

        // GET Crear
        public IActionResult Crear() => View(new UsuarioDto());

        // POST /Usuarios
        [HttpPost]
        public async Task<IActionResult> Crear(UsuarioDto modelo)
        {
            var resp = await _http.PostAsJsonAsync("Usuarios", modelo);
            if (!resp.IsSuccessStatusCode) return View(modelo);
            return RedirectToAction(nameof(Index));
        }

        // GET Editar
        public async Task<IActionResult> Editar(int id)
        {
            var usuario = await _http.GetFromJsonAsync<UsuarioDto>($"Usuarios/{id}");
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        // PUT /Usuarios
        [HttpPost]
        public async Task<IActionResult> Editar(UsuarioDto modelo)
        {
            var resp = await _http.PutAsJsonAsync("Usuarios", modelo);
            if (!resp.IsSuccessStatusCode) return View(modelo);
            return RedirectToAction(nameof(Index));
        }

        // DELETE /Usuarios/{id}
        public async Task<IActionResult> Eliminar(int id)
        {
            var resp = await _http.DeleteAsync($"Usuarios/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
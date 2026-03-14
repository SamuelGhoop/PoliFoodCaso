using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;
using PoliFoodCaso.Services;

namespace PoliFoodCaso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Student")]

    public class CarritoController : Controller
    {
        private readonly ICarritoService _carritoService;

        public CarritoController(ICarritoService carritoService)
        {
            _carritoService = carritoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetByStudent(string studentId) =>
            Ok(await _carritoService.GetByStudent(studentId));

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] CarritoItem item)
        {
            var itemCreado = await _carritoService.AddItem(item);
            return Ok(itemCreado);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, [FromBody] int cantidad)
        {
            return await _carritoService.UpdateItem(id, cantidad) ? Ok("Cantidad actualizada en el carrito") : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveItem(Guid id)
        {
            return await _carritoService.RemoveItem(id) ? Ok("Producto eliminado del carrito") : NotFound();
        }
    }
}

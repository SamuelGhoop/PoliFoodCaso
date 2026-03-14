using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;

namespace PoliFoodCaso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Vendor")]
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{tiendaId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTienda(Guid tiendaId) =>
            Ok(await _productoService.GetByTienda(tiendaId));

        [HttpGet("detalle/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var producto = await _productoService.GetById(id);
            return producto != null ? Ok(producto) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Producto producto)
        {
            var productoCreado = await _productoService.Create(producto);
            return CreatedAtAction(nameof(GetById), new { id = productoCreado.id_producto }, productoCreado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Producto producto)
        {
            return await _productoService.Update(id, producto) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _productoService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del producto") : NotFound();
        }
    }
}

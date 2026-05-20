using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoliFoodCaso.DAO;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;
using System.Security.Claims;

namespace PoliFoodCaso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Vendor")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly ApplicationDbContext _context;

        public ProductoController(IProductoService productoService, ApplicationDbContext context)
        {
            _productoService = productoService;
            _context = context;
        }

        private async Task<bool> VendorOwnsCategoria(string userId, Guid categoriaId)
        {
            return await _context.Categoria
                .AnyAsync(c => c.id_categoria == categoriaId && c.tienda!.vendorId == userId);
        }

        private async Task<bool> VendorOwnsProducto(string userId, Guid productoId)
        {
            return await _context.Producto
                .AnyAsync(p => p.id_producto == productoId && p.categoria!.tienda!.vendorId == userId);
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();
            if (!await VendorOwnsCategoria(userId, producto.categoriaId))
                return Forbid();

            var productoCreado = await _productoService.Create(producto);
            return CreatedAtAction(nameof(GetById), new { id = productoCreado.id_producto }, productoCreado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Producto producto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();
            if (!await VendorOwnsProducto(userId, id))
                return Forbid();
            //Si el body trae otra categoriaId, validar que también sea del vendor
            if (!await VendorOwnsCategoria(userId, producto.categoriaId))
                return Forbid();

            return await _productoService.Update(id, producto) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();
            if (!await VendorOwnsProducto(userId, id))
                return Forbid();

            return await _productoService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del producto") : NotFound();
        }
    }
}
